using AspNetCoreService.Repository;
using Autofac;

namespace AspNetCoreService
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterType(typeof(Repository.Repository)).As(typeof(IRepository)).SingleInstance();
        }
    }    
}
