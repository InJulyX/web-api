using System;

namespace Web.Api
{
    public static class ServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}