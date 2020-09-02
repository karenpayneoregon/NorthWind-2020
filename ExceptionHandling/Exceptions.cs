using System;
using System.IO;
using static System.IO.File;

namespace ExceptionHandling
{
    /// <summary>
    /// Provides writing run time exceptions to a text file
    /// </summary>
    public static class Exceptions
    {
        /// <summary>
        /// Write Exception information to UnhandledException.txt in the executable folder.
        /// </summary>
        /// <param name="exception">Strong typed <seealso cref="Exception"/></param>
        public static void Write(Exception exception)
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UnhandledException.txt");
            if (Exists(fileName))
            {
                var contents = ReadAllText(fileName);
                var current = exception.ToLogString(Environment.StackTrace);
                var data = $"{contents}{Environment.NewLine}{current}{Environment.NewLine}";
                WriteAllText(fileName, data);
            }
            else
            {
                WriteAllText(fileName, exception.ToLogString(Environment.StackTrace) + Environment.NewLine);
            }
        }
    }
}