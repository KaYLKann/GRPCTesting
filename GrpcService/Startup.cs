using Calculator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcService {
    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddGrpc();
            services.AddTransient<IExponentiationOperation<double>,ExponentiationOperation>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                                 endpoints.MapGrpcService<CalcService>();
                             });
        }
    }
}