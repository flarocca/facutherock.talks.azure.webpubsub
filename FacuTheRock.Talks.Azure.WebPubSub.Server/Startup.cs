using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FacuTheRock.Talks.Azure.WebPubSub.Server
{
    public class Startup
    {
        private const string ConnectionString = "<< Connection String >>";
        private const string Hub = "<< Hub >>";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAzureClients(builder =>
            {
                builder.AddWebPubSubServiceClient(ConnectionString, Hub);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FacuTheRock.Talks.Azure.WebPubSub.Server", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FacuTheRock.Talks.Azure.WebPubSub.Server v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
