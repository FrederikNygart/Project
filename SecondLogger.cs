using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project
{
    internal class SecondLogger
    {
        
        internal async Task InvokeAsync(HttpContext ctx, RequestDelegate next)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            await next(ctx);
            Console.WriteLine($" 2nd logger actoin:{sw.ElapsedMilliseconds}");

        }
    }
}