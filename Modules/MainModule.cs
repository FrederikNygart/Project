using Nancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get("/", ( _ )=> { return new { Age = 31 }; });
        }

    }
}
