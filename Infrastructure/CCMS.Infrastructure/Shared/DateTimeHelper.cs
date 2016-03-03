using System;

namespace CCMS.Infrastructure.Shared
{
    public static class DateTimeHelper
    {
        public static DateTime ToLocalTime(this object epochTime)
        {
            return epochTime.ToUtcTime().ToLocalTime();
        }

        public static DateTime ToUtcTime(this object epochTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(Convert.ToDouble(epochTime));
        }

        public static double ToEpochTime(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

    }
}
