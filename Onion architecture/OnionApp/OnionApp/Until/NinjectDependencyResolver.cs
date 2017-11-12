using Ninject;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using OnionApp.Infrastructure.Business.OrderProduct;
using OnionApp.Infrastructure.Data.Repositories;
using OnionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnionApp.Until
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IGenericRepository<User>>().To<UserRepository>();
            kernel.Bind<IGenericRepository<Product>>().To<ProductRepository>();
            kernel.Bind<IGenericRepository<Category>>().To<CategoryRepository>();
            kernel.Bind<IGenericRepository<Store>>().To<StoreRepository>();
            kernel.Bind<IOrder>().To<CacheOrder>();
        }
    }
}