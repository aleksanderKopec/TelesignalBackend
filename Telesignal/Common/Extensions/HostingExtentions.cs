using Microsoft.EntityFrameworkCore;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Sample.Config;

namespace Telesignal.Common.Extensions;

public static class HostingExtensions
{
    public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder,
                                                          string databaseConnectionString) {
        builder.Services.AddDbContext<DatabaseContext>(
            options => options.UseSqlServer(databaseConnectionString)
        );
        return builder;
    }

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder) {
        // Build in services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSignalR();
        SampleDependencyConfiguration.AddDependencies(builder.Services);
        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app) {
        if (app.Environment.IsDevelopment()) {
            app.UseDeveloperExceptionPage()
               .UseSwagger()
               .UseSwaggerUI();
        }

//        app.UseHttpsRedirection();
//        app.UseRouting();
        app.UseAuthentication()
           .UseAuthorization();

        app.MapControllers();
        return app;
    }
}
