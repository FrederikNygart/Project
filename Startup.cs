using Microsoft.AspNetCore.Builder;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using Nancy.Owin;
using System.Collections;
using System.Collections.Generic;
using AppFunc = System.Func<System.Collections.Generic.Dictionary<string, object>, System.Threading.Tasks.Task>;
using Microsoft.Extensions.DependencyInjection;

namespace Project
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(buildFunc =>
            {
                buildFunc(next => async ctx =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    await next(ctx);
                    Console.WriteLine($"Action to exe: {stopWatch.ElapsedMilliseconds}");
                });
                buildFunc(next => async ctx => await new Logger(next).Invoke(ctx));
                buildFunc(next => async ctx => await new Authenticator(next).Invoke(ctx));
                buildFunc.UseNancy();                  
            });
        }
    }
}