using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPantry.StringWriters.Implementation.Console
{
    public class StandardConsoleAppendWriterCollection : IAppendWriterCollection
    {
        public AppendStringWriter Standard { get; private set; }
        public AppendStringWriter Warning { get; private set; }
        public AppendStringWriter Error { get; private set; }
        public AppendStringWriter Debug { get; private set; }
        public AppendStringWriter Verbose { get; private set; }

        public AppendStringWriter GreyAccent { get; private set; }
        public AppendStringWriter BlueAccent { get; private set; }
        public AppendStringWriter GreenAccent { get; private set; }

        public StandardConsoleAppendWriterCollection()
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
