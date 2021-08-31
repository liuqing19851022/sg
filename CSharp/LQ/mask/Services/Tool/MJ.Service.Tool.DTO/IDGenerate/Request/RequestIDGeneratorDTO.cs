#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：RequestIDGeneratorDTO.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJSaas.Services.IDGenerate.DTO
// 	* 文 件 名：RequestIDGeneratorDTO.cs
// 	* 创建时间：2016-05-04 17:26
// 	* 作    者： MJKJ.用户名：>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion


namespace MJ.Service.Tool.DTO.IDGenerate.Request
{
    using System;
    using System.Runtime.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Orleans.Concurrency;

    /// <summary>
    /// 请求生成ID
    /// </summary>
    [DataContract]
    [Serializable]
    [Immutable]
    public class RequestIDGeneratorDTO
    {
        [DataMember]
        [Required(ErrorMessage = "请输入表名，表明格式：数据库名.数据表名!")]
        public string TableName { get; set; }
    }
}