namespace MJUSS.Infrastructure.Core.BaseTypes
{
    /// <summary>
    /// 通用的等待处理任务状态
    /// </summary>
    public enum CommonPendingTaskDataStateEnum
    {
        未处理 = 1,
        已处理 = 2,
        已取消 = 3,
        异常 = 4,
    }
}
