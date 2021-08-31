namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class DoubleExtention
    {
        public static string ToFirendlyTimeLenth(this double timeDiffMins) {
            var pauseHours = ((int)(timeDiffMins / 60)).ToString();
            var pauseMins = (timeDiffMins % 60).ToString("F0");
            return $"{pauseHours}小时{pauseMins}分钟";
        }
    }
}
