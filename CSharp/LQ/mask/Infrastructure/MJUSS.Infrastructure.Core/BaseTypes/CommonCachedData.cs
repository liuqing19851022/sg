using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.BaseTypes
{
    public class CommonCachedData<T>
    {
        private T value;
        public T Value
        {
            get
            {
                return value;
            }
        }

        public T GetValue()
        {
            if (IsExpire)
                return default(T);
            return value;
        }

        public DateTime Expire { get; private set; } = DateTime.Now.AddDays(-1);

        public bool IsExpire => Expire < DateTime.Now || value == null;

        public void SetValue(T data, TimeSpan timeSpan)
        {
            value = data;
            Expire = DateTime.Now.Add(timeSpan);
        }

    }
}
