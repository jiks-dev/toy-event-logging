using Microsoft.Extensions.DependencyInjection;
using Toy.Pubsub.Services;

namespace Toy.Pubsub.Extensions
{
    public static class PubSubServiceExtension
    {
        public static IServiceCollection AddPubSubService(this IServiceCollection services) 
        {
            services.AddSingleton<IPubSubManager, PubSubManager>();
            services.AddScoped<IPubSubService, PubSubService>();

            return services;
        }
    }
}
