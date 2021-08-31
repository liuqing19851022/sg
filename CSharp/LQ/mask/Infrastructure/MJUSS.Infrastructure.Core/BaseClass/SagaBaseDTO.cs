#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：SagaBaseDTO.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Core
// 	* 文 件 名：SagaBaseDTO.cs
// 	* 创建时间：2016-07-11 17:45
// 	* 作    者： MJKJ.hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Core.BaseClass
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Saga传输对象基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [DataContract]
    public class SagaBaseDTO<T> where T:class,new()
    {
        public SagaBaseDTO()
        {
            this.OriginalRequestData=new T();
        }

        [DataMember]
        public T OriginalRequestData { get; set; }

        public SagaBaseDTO(T originalRequestData)
        {
            this.OriginalRequestData = originalRequestData;
        }
        
    }
}