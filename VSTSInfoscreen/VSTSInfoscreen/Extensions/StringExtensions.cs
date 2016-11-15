namespace System
{
    /// <summary>
    /// Contains all extensions for the <see cref="string"/> class. 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Trims the string after a certain amount of characters.
        /// </summary>
        /// <param name="str">The string to extend.</param>
        /// <param name="after">The count of characters after which to trim.</param>
        /// <returns>Returns the trimmed string.</returns>
        public static string TrimAfter(this string str, int after) =>
            str.Length <= after ? str : $"{str.Substring(0, after - 3)}...";
    }
}