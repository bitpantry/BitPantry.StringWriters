using System;

namespace BitPantry.StringWriters.Implementation.Console
{
    public class ConsoleAppendWriter : AppendStringWriter
    {
        private readonly ConsoleColor _foregroundColor;
        private readonly ConsoleColor _backgroundColor;

        public ConsoleAppendWriter() : this(System.Console.ForegroundColor) { }
        public ConsoleAppendWriter(ConsoleColor forecolor) : this(forecolor, System.Console.BackgroundColor) { }
        public ConsoleAppendWriter(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            _foregroundColor = foregroundColor;
            _backgroundColor = backgroundColor;
        }

        protected override void OnAppend(string str) { ConsoleWrapper.Append(str, _foregroundColor, _backgroundColor); }
    }
}
