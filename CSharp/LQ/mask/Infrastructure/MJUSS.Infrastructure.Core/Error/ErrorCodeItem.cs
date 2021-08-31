namespace MJUSS.Infrastructure.Core.Error
{
    /// <summary>
    /// 错误编码项
    /// </summary>
    public class ErrorCodeItem
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMessage">错误消息</param>
        public ErrorCodeItem(int errorCode, string errorMessage = "")
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
    }
}