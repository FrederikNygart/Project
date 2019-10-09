using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Project
{
    internal class Logger
    {
        private Func<IDictionary<string, object>, Task> next;

        public Logger(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        internal async Task Invoke(IDictionary<string,object> ctx)
        {
            var sw = new Stopwatch();
            sw.Start();
            await next(ctx);
            Console.WriteLine($"logger actoin:{sw.ElapsedMilliseconds}");

        }
    }
}