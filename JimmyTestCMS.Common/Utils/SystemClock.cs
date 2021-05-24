using System;

namespace JimmyTestCMS.Common.Utils
{
    public class SystemClock: IClock
    {
        public DateTime GetUtc()
        {
            return DateTime.UtcNow;
        }
    }
}