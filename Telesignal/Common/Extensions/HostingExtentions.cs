using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Telesignal.Common.Config;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.IdentityServer.Config;
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


    public static WebApplicationBuilder ConfigureIdentityServer(this WebApplicationBuilder builder) {
        builder.Services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<DatabaseContext>()
               .AddDefaultTokenProviders();

        builder.Services
               .AddIdentityServer(options => {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                    options.EmitStaticAudienceClaim = true;
                })
               .AddInMemoryIdentityResources(ResourcesConfig.IdentityResources)
               .AddInMemoryApiScopes(ResourcesConfig.ApiScopes)
               .AddInMemoryClients(ResourcesConfig.Clients)
               .AddAspNetIdentity<User>();

        builder.Services
               .AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", options => {
                    options.Authority = AppSettings.AppUrl;
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateAudience = false
                    };
                });
        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app) {
        if (app.Environment.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

//        app.UseHttpsRedirection();
//        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}
