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

        public ConsolidatedStringWriter GreyAccent { get; private set; }
        public ConsolidatedStringWriter BlueAccent { get; private set; }
        public ConsolidatedStringWriter GreenAccent { get; private set; }

        public StandardConsoleWriterCollection()
        {
            Standard = new ConsoleAppendWriter();
            Warning = new ConsoleAppendWriter(ConsoleColor.Yellow);
            Error = new ConsoleAppendWriter(ConsoleColor.Red);
            Debug = new ConsoleAppendWriter(ConsoleColor.White);
            Verbose = new ConsoleAppendWriter(ConsoleColor.DarkGray);
            
            GreyAccent = new ConsoleAppendWriter(ConsoleColor.Gray, ConsoleColor.DarkGray);
            BlueAccent = new ConsoleAppendWriter(ConsoleColor.White, ConsoleColor.Blue);
            GreenAccent = new ConsoleAppendWriter(ConsoleColor.Green, ConsoleColor.DarkGreen);
        }
    }
}
