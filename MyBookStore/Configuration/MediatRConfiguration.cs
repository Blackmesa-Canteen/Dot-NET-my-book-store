

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MyBookStore.Configuration
{
    public static class MediatRConfiguration
    {
        public static void AddMediaRConfiguration(this IServiceCollection services)
        {
            // inject command handler mediator object from class library
            services.AddMediatR(Assembly.Load("MyBookStore.DAL"));
        }
    }
}