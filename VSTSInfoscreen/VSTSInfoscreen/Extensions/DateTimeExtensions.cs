namespace System
{
    /// <summary>
    /// Contains all extensions for the <see cref="DateTime"/> struct. 
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets a readable date to display the user.
        /// </summary>
        /// <param name="date">The date to extend.</param>
        /// <returns>Returns a readable date.</returns>
        public static string GetReadableDate(this DateTime date)
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;
            var ts = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
            var delta = Math.Abs(ts.TotalSeconds);
            if (delta < 1 * minute)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            else if (delta < 2 * minute)
            {
                return "a minute ago";
            }
            else if (delta < 45 * minute)
            {
                return ts.Minutes + " minutes ago";
            }
            else if (delta < 90 * minute)
            {
                return "an hour ago";
            }
            else if (delta < 24 * hour)
            {
                return ts.Hours + " hours ago";
            }
            else if (delta < 48 * hour)
            {
                return "yesterday";
            }
            else if (delta < 30 * day)
            {
                return ts.Days + " days ago";
            }
            else if (delta < 12 * month)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}