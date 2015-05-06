using System;

namespace BitPantry.StringWriters.Implementation.Console
{
    /// <summary>
    /// Locks access to the console for append operations by the ConsoleAppendWriter
    /// </summary>
    static class ConsoleWrapper
    {
        static readonly object Locker = new object();

        /// <summary>
        /// Appends the specified string to the console output
        /// </summary>
        /// <param name="str">The string to append</param>
        /// <param name="foregroundColor">Foreground color to use.</param>
        /// <param name="backgroundColor">Background color to use.</param>
        public static void Append(string str, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            lock (Locker)
            {
                var backupForegroundcolor = System.Console.ForegroundColor;
                var backupBackgroundColor = System.Console.BackgroundColor;

                System.Console.ForegroundColor = foregroundColor;
                System.Console.BackgroundColor = backgroundColor;

                System.Console.Write(str);

                System.Console.ForegroundColor = backupForegroundcolor;
                System.Console.BackgroundColor = backupBackgroundColor;
            }
        }
    }
}
