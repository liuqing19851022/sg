#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：GenerateTsViewModel.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Core
// 	* 文 件 名：GenerateTsViewModel.cs
// 	* 创建时间：2016-05-28 14:50
// 	* 作    者： MJKJ.hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    using System;

    /// <summary>
    /// 标记生成TypeScript ViewModel
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GenerateTsViewModel: Attribute
    {
         
    }
}