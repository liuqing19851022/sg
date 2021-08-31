using MJ.Domain.Mask.Shared.Constants;
using MJUSS.Infrastructure.Core.Constants;
using MJUSS.Infrastructure.Core.CustomAttributes;
using Orleans;
using Orleans.CodeGeneration;
using Orleans.Concurrency;
using Orleans.Transactions.Abstractions;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace MJ.Mask.Implement.Test.Domain
{
    [Collection(ClusterCollection.Name)]
    public class DomainServiceCheckTest
    {

        private readonly ITestOutputHelper Output;

        public DomainServiceCheckTest(ITestOutputHelper output)
        {
            this.Output = output;
        }

        [Theory]
        [InlineData("MJ.Domain.Mask.Implement.dll")]

        public void DomainServiceTestCase(string dllName) {

            var types = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), dllName)).GetExportedTypes();
            var grainType = typeof(Grain);

            foreach (var type in types) {

                if (grainType.IsAssignableFrom(type)) {

                    if (!type.BaseType.FullName.StartsWith("MJ.Service.Tool.Implement.Domain.MJDomainGrain`1[["))
                    {
                        Output.WriteLine($"{type.FullName} 未继承 MJDomainGrain<T>");
                        continue;
                    }

                    var attrs = type.GetCustomAttributes(typeof(ReentrantAttribute), false);
                    if (attrs.Length == 0) {
                        Output.WriteLine($"{type.FullName}未添加 [Reentrant] 特性");
                    }

                    Assert.Single(attrs);

                    //检查构造函数
                    var constructor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

                    var parm = constructor.FirstOrDefault().GetParameters().FirstOrDefault(p=>p.ParameterType.Name == "ITransactionalState`1");

                    if (parm == null) {
                        Output.WriteLine($"{type.FullName}未找到构造函数中的 ITransactionalState 参数");
                        continue;
                    }

                    Assert.NotNull(parm);

                    var consAttr =  parm.GetCustomAttribute(typeof(TransactionalStateAttribute));

                    var fullName = parm.ParameterType.FullName;
                    fullName = fullName.Substring(fullName.IndexOf("[["));
                    fullName = fullName.Substring(0, fullName.IndexOf(','));
                    fullName = fullName.Substring(fullName.LastIndexOf('.') + 1);

                    if (consAttr == null)
                    {
                        Output.WriteLine($"{type.FullName}未找到构造函数中的 {parm.Name} 参数 没有 [TransactionalState] 特性,请添加");
                        Output.WriteLine($"[TransactionalState(nameof({fullName.Substring(fullName.LastIndexOf('.')+1)}), MaskTransactionalStorageNameConstants.Mask)]");
                    }

                    Assert.NotNull(consAttr);

                    if (consAttr is TransactionalStateAttribute tmp)
                    {
                        Assert.Equal(MaskTransactionalStorageNameConstants.Mask, tmp.StorageName);
                        Assert.Equal(fullName, tmp.StateName);
                    }
                }

            }

        }



        [Theory]
        [InlineData("MJ.Domain.Mask.Interface.dll")]
        [InlineData("MJ.DomainService.Mask.Interface.dll")]
        public void InterfaceTestCase(string dllName) {
            var types = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), dllName)).GetExportedTypes(); ;

            var grainType = typeof(IGrain);

            foreach (var type in types)
            {
                if (dllName.StartsWith("MJ.Domain.") && type.IsClass) {

                    var attrState = type.GetCustomAttribute<DomainStateAttribute>();
                    //实体
                    if (type.Name.EndsWith("State") && type.Namespace.EndsWith("State")) {

                        if (attrState == null) {

                            var fullName = $"MJ.Service.Tool.Interface.Domain.IMJDomainGrain`1[[{type.FullName},";
                            //查看是否接口暴露
                            if (types.Any(p => {
                                return p.GetInterfaces().Any(q=>q.FullName.StartsWith(fullName));

                            })) {

                                Output.WriteLine($"{type.FullName} 未添加 [DomainState] 特性");
                                Assert.Equal(1,0);
                            }
                        } 
                    }
                    else 
                    {
                        if (attrState != null) {
                            Output.WriteLine($"{type.FullName} 意外的添加 [DomainState] 特性");
                        }
                        Assert.Null(attrState);
                    }

                }

                if (!type.IsInterface)
                {
                    continue;
                }

                if (!grainType.IsAssignableFrom(type)) 
                    continue;
 
                var interfaces = type.GetInterfaces();

                if (!interfaces.Any(p => p.FullName.Equals("Orleans.Runtime.IAddressable")))
                {
                    Output.WriteLine($"{type.Name} 未继承 IAddressable 接口");
                    continue;
                }

                if (dllName.StartsWith("MJ.Domain.") && !interfaces.Any(p=>p.FullName.StartsWith("MJ.Service.Tool.Interface.Domain.IMJDomainGrain`1[["))) {

                    Output.WriteLine($"{type.Name} 未继承 IMJDomainGrain 接口");
                    continue;
                }
                

                var attrs = type.GetCustomAttributes(typeof(VersionAttribute), false);
                if (attrs.Length == 0)
                {
                    Output.WriteLine($"{type.FullName} 未添加 [Version] 特性,请添加");
                    Output.WriteLine($"[Version(SysPredefined.Version)]");
                }

                Assert.Single(attrs);

                var verAttr = attrs.FirstOrDefault() as VersionAttribute;
                Assert.Equal(SysPredefined.Version,verAttr.Version);

                var methods = type.GetMethods();

                foreach (var method in methods)
                {
                    var transAttrs = method.GetCustomAttributes(typeof(TransactionAttribute), false);
                    if (transAttrs.Length == 0)
                    {
                        Output.WriteLine($"{type.FullName}/{method.Name}未添加 [Transaction] 特性,根据实际情况添加");
                        Output.WriteLine("[Transaction(TransactionOption.CreateOrJoin)]");
                        Output.WriteLine("或");
                        Output.WriteLine("[Transaction(TransactionOption.Suppress)]");
                    }
                    Assert.Single(transAttrs);

                    var esAttrs = method.GetCustomAttributes(typeof(AutoToReadDataBaseAttribute),true);
                    if (esAttrs.Length != 0)
                    {
                        Output.WriteLine($"{type.FullName}/{method.Name}意外添加了 AutoToReadDataBase 特性");
                    }
                    Assert.Empty(esAttrs);

                }
            }
        }
    }
}
