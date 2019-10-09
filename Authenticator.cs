using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project
{
    internal class Authenticator
    {
        private Func<IDictionary<string, object>, Task> next;

        public Authenticator(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        internal async Task Invoke(IDictionary<string, object> ctx)
        {
            await next(ctx);
            Console.WriteLine($"aUTHENTICATED");
        }
    }
}