
namespace MJUSS.Infrastructure.Utils.Helper
{
    using System;

    public static class RetryTools
    {
        public static void Retry3Time(Action action)
        {
            for (var i = 0; i < 3; i++)
            {
                try
                {
                    action();
                    break;
                }
                catch(Exception ex)
                {
                    if (i >= 2)
                        throw new Exception(ex.Message);
                }
            }
        }
        public static T Retry3Time<T>(Func<T> func)
        {
            var result = default(T);
            for (var i = 0; i < 3; i++)
            {
                try
                {
                    result = func();
                    break;
                }
                catch (Exception ex)
                {
                    if (i >= 2)
                        throw new Exception(ex.Message);
                }
            }
            return result;
        } 
    }
}