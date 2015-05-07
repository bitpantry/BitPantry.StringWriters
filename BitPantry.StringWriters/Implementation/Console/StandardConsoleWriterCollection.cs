using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPantry.StringWriters.Implementation.Console
{
    public class StandardConsoleWriterCollection : IConsolidatedStringWriterCollection
    {
        public ConsolidatedStringWriter Standard { get; private set; }
        public ConsolidatedStringWriter Warning { get; private set; }
        public ConsolidatedStringWriter Error { get; private set; }
        public ConsolidatedStringWriter Debug { get; private set; }
        public ConsolidatedStringWriter Verbose { get; private set; }

        public ConsolidatedStringWriter Accent1 { get; private set; }
        public ConsolidatedStringWriter Accent2 { get; private set; }
        public ConsolidatedStringWriter Accent3 { get; private set; }

        public StandardConsoleWriterCollection()
        {
            Standard = new ConsoleAppendWriter();
            Warning = new ConsoleAppendWriter(ConsoleColor.Yellow);
            Error = new ConsoleAppendWriter(ConsoleColor.Red);
            Debug = new ConsoleAppendWriter(ConsoleColor.White);
            Verbose = new ConsoleAppendWriter(ConsoleColor.DarkGray);
            
            Accent1 = new ConsoleAppendWriter(ConsoleColor.Gray, ConsoleColor.DarkGray);
            Accent2 = new ConsoleAppendWriter(ConsoleColor.White, ConsoleColor.Blue);
            Accent3 = new ConsoleAppendWriter(ConsoleColor.Green, ConsoleColor.DarkGreen);
        }
    }
}
