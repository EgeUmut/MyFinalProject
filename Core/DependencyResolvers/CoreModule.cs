
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{   //injection kısımları
    public class CoreModule : ICoreModule
    {
        public void load(IServiceCollection serviceCollection)
        {
            //singleton kısımlarını buraya aldık
            serviceCollection.AddMemoryCache(); //generic cache
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); // yeni bir cache methoduna geçmek istersen Memory yazısını değiştirmen yeterli
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
