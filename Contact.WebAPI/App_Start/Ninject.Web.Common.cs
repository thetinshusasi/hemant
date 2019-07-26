[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Contact.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Contact.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace Contact.WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Contact.DAL.Contexts;
    using Contact.DAL.IRepositories;
    using System.Data.Entity;
    using Contact.DAL.Repositories;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
           
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
          
            kernel.Bind<IAddressRepository>().To<AddressRepository>();
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            kernel.Bind<ICountryRepository>().To<CountryRepository>();
            kernel.Bind<ILogoRepository>().To<LogoRepository>();
            kernel.Bind<IOrganisationRepository>().To<OrganisationRepository>();
            kernel.Bind<IPositionRepository>().To<PositionRepository>();
            kernel.Bind<ISloganRepository>().To<SloganRepository>();
            kernel.Bind<IStateRepository>().To<StateRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<DbContext>().To<SqlContext>();
        }        
    }
}