using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Repository.Business.Abstract;
using Repository.Business.Concrete;
using Repository.DataAccess.Utilities.Resolvers.Autofac;

namespace Repository.Business.Utilities.Resolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccessModule());

            builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<UserManager>().As<IUserService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<DealerManager>().As<IDealerService>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<ProducerManager>().As<IProducerService>().SingleInstance();
            builder.RegisterType<ProductPartManager>().As<IProductPartService>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductTypeManager>().As<IProductTypeService>().SingleInstance();
            builder.RegisterType<CalculateManager>().As<ICalculateService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}