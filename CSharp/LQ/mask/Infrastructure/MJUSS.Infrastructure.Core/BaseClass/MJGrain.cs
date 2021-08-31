using Orleans;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.BaseClass
{
    /// <summary>
    /// GrainTimer数据
    /// </summary>
    [Serializable]
    [DataContract]
    public class GrainTimerState
    {
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public object State { get; set; }
        /// <summary>
        /// 维护定时器字典的Key
        /// </summary>
        [DataMember]
        public Guid Key { get; set; }
    }
    /// <summary>
    /// Grain基类
    /// </summary>
    public class MJGrain : Grain        
    {
        /// <summary>
        /// 存放定时器的字典
        /// </summary>
        private readonly Dictionary<Guid, IDisposable> TimerDictionary = new Dictionary<Guid, IDisposable>();
        /// <summary>
        /// 注册自动注销的定时器
        /// </summary>
        /// <param name="asyncCallback"></param>
        /// <param name="state"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        protected Task RegisterTimerAutoDispose(Func<object, Task> asyncCallback, object state, TimeSpan dueTime, TimeSpan period)
        {
            var key = Guid.NewGuid();
            GrainTimerState timerKey = new GrainTimerState
            {
                Key = key,
                State = state
            };
            state = timerKey;
            var _timer = base.RegisterTimer(
                async data =>
                {
                    var stateData = (GrainTimerState)state;
                    await asyncCallback(stateData.State);
                    await TimerCompleted(stateData.Key);
                }, state, dueTime, period);
            if (this.TimerDictionary.ContainsKey(key))
            {
                this.TimerDictionary[key].Dispose();
                this.TimerDictionary.Remove(key);
            }
            this.TimerDictionary.Add(key, _timer);
            return Task.CompletedTask;
        }
        /// <summary>
        /// 定时器完成处理
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private Task TimerCompleted(Guid key)
        {
            if (this.TimerDictionary.ContainsKey(key))
            {
                var _timer = TimerDictionary[key];
                if (_timer != null)
                {
                    _timer.Dispose();
                }
                this.TimerDictionary.Remove(key);
            }
            return Task.CompletedTask;
        }
    }
}
