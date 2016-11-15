namespace System
{
    /// <summary>
    /// Contains all extensions for the <see cref="TimeSpan"/> class. 
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Gets a readable version of the <see cref="TimeSpan"/>. 
        /// </summary>
        /// <param name="t">The <see cref="TimeSpan"/> to extend.</param>
        /// <returns>Returns the readable string.</returns>
        public static string GetReadableTimeSpan(this TimeSpan t)
        {
            if (t.TotalSeconds <= 1)
            {
                return $@"{t:s\.ff} seconds";
            }
            else if (t.TotalMinutes <= 1)
            {
                return $@"{t:%s} seconds";
            }
            else if (t.TotalHours <= 1)
            {
                return $@"{t:%m} minutes";
            }
            else if (t.TotalDays <= 1)
            {
                return $@"{t:%h} hours";
            }

            return $@"{t:%d} days";
        }
    }
}