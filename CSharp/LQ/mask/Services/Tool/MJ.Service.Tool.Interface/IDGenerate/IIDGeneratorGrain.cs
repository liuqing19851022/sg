#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：IIDGeneratorGrain.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJSaas.Services.IDGenerate.Interface
// 	* 文 件 名：IIDGeneratorGrain.cs
// 	* 创建时间：2016-05-04 17:31
// 	* 作    者： MJKJ.用户名：>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion


namespace MJ.Service.Tool.Interface.IDGenerate
{
    using System.Threading.Tasks;
    using MJ.Service.Tool.DTO.IDGenerate.Request;
    using MJ.Service.Tool.DTO.IDGenerate.Respond;
    using MJUSS.Infrastructure.Core.BaseClass;
    using Orleans;

    public interface IIDGeneratorGrain : IGrainWithStringKey
    {
        /// <summary>
        /// 生成ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Suppress)]
        Task<long> GenerateID();
    }
}