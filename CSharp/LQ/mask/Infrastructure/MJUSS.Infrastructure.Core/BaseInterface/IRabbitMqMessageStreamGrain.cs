#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：IRabbitMqMessageStreamGrain.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Core
// 	* 文 件 名：IRabbitMqMessageStreamGrain.cs
// 	* 创建时间：2016-05-09 17:54
// 	* 作    者： MJKJ.用户名：hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Core.BaseInterface
{
    using System.Threading.Tasks;

    using Orleans;

    public interface IRabbitMqMessageStreamGrain: IGrainWithGuidKey
    {
        Task Start();

        Task Stop();
    }
}