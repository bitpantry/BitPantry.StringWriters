using System.IO;
using System.Text;

namespace BitPantry.StringWriters
{
    /// <summary>
    /// This class provides all standard text writer functions as implemented by the StringWriter. All functions are consolidated
    /// to a single handler, OnWrite, that should be implemented by any extending class.
    /// </summary>
    public abstract class ConsolidatedStringWriter : StringWriter
    {
        public override void Write(char value) { WriteGeneric(value); }
        public override void Write(string value) { WriteGeneric(value); }
        public override void Write(bool value) { WriteGeneric(value); }
        public override void Write(int value) { WriteGeneric(value); }
        public override void Write(double value) { WriteGeneric(value); }
        public override void Write(long value) { WriteGeneric(value); }
        public override void Write(string format, params object[] args) { WriteGeneric(string.Format(format, args)); }

        public override void WriteLine(char value) { WriteLineGeneric(value); }
        public override void WriteLine(string value) { WriteLineGeneric(value); }
        public override void WriteLine(bool value) { WriteLineGeneric(value); }
        public override void WriteLine(int value) { WriteLineGeneric(value); }
        public override void WriteLine(double value) { WriteLineGeneric(value); }
        public override void WriteLine(long value) { WriteLineGeneric(value); }
        public override void WriteLine(string format, params object[] arg) { WriteLineGeneric(string.Format(format, arg)); }

        private void WriteGeneric<T>(T value) { OnWrite(value.ToString()); }
        private void WriteLineGeneric<T>(T value) { OnWrite(string.Format("{0}{1}", value == null ? null : value.ToString(), NewLine)); }

        public override void Write(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
            var buffer2 = new char[count]; //Ensures large buffers are not a problem
            for (int i = 0; i < count; i++) buffer2[i] = buffer[index + i];
            WriteGeneric(CharArrToString(buffer2));
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
            var buffer2 = new char[count]; //Ensures large buffers are not a problem
            for (var i = 0; i < count; i++) buffer2[i] = buffer[index + i];
            WriteLineGeneric(CharArrToString(buffer2));
        }

        private string CharArrToString(char[] arr)
        {
            var strBldr = new StringBuilder();
            foreach (var t in arr)
                strBldr.Append(t);
            return strBldr.ToString();
        }

        /// <summary>
        /// All write functions funnel into this function
        /// </summary>
        /// <param name="str">The string representation of data written to the output</param>
        protected abstract void OnWrite(string str);

    }
}
