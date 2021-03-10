using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Web.Common
{
    public class AutoFacModuleRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetAssemblyByName("Web.Repository"))
                .Where(a => a.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .SingleInstance();
            builder.RegisterAssemblyTypes(GetAssemblyByName("Web.Service"))
                .Where(a => a.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        private static Assembly GetAssemblyByName(string name)
        {
            return Assembly.Load(name);
        }
    }
}