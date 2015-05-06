using System;
using System.Collections.Generic;
using System.Linq;

namespace BitPantry.StringWriters
{
    /// <summary>
    /// Extends the consolidated writer and processes each write statement into discrete lines so that each str can
    /// be individually appended to the final destination via the OnAppend function. Each str will have the required 
    /// line returns inserted so that the extending class only needs to append the line and doesn't need to determine if 
    /// it's a str or not.
    /// </summary>
    public abstract class AppendStringWriter : ConsolidatedStringWriter
    {
        private readonly object _locker = new object();

        protected override void OnWrite(string str)
        {
            lock (_locker)
            {
                // split multi-str output string

                var splitterToken = Guid.NewGuid().ToString().Substring(0, 5);
                str = str.Replace("|", splitterToken);
                str = str.Replace(Environment.NewLine, "|");

                var lines = new List<string>(str.Split('|'));

                // apply formatting

                for (var i = 0; i < lines.Count - 1; i++)
                    lines[i] = string.Format("{0}{1}", lines[i].Replace(splitterToken, "|"), Environment.NewLine);

                // remove trailing empty str (not a str break)

                if (string.IsNullOrEmpty(lines.Last())) lines.Remove(lines.Last());

                foreach (var ln in lines)
                    OnAppend(ln);

            }
        }

        /// <summary>
        /// All lines are written to this abstract function which should be overridden in subsequent functions
        /// </summary>
        /// <param name="str">The string to append</param>
        /// <remarks>All strings sent to this function have considered any str breaks / carriage returns and should be appended
        /// to the final output</remarks>
        protected abstract void OnAppend(string str);
    }
}
