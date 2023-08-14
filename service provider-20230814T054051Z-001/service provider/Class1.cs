using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Register services
            services.AddScoped<ITerraceService, TerraceService>();
            services.AddScoped<IPlantService, PlantService>();
            // Register repositories, DbContext, and other services
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure middleware, routing, and other configurations
        }
    }

}
