using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Telesignal.Auth.Config;
using Telesignal.Chat;
using Telesignal.Common.Config;
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
        ConfigDependencyConfiguration.AddDependencies(builder.Services);
        SampleDependencyConfiguration.AddDependencies(builder.Services);
        AuthDependencyConfiguration.AddDependencies(builder.Services);
        return builder;
    }

    public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder) {
        var jwtAudience = builder.Configuration[AppSettings.JwtAudience];
        var jwtIssuer = builder.Configuration[AppSettings.JwtIssuer];
        var jwtKey = builder.Configuration[AppSettings.JwtKey];
        builder.Services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidIssuer = jwtAudience,
                ValidAudience = jwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = false
            };
        });
        return builder;
    }

    public static WebApplicationBuilder ConfigureAuthorization(this WebApplicationBuilder builder) {
        builder.Services.AddAuthorization();
        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app) {
        if (app.Environment.IsDevelopment()) {
            app.UseDeveloperExceptionPage()
               .UseSwagger()
               .UseSwaggerUI();
        }

        app.UseHttpsRedirection();
//        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        return app;
    }

    public static WebApplication ConfigureSinglaR(this WebApplication app, string mainPath) {
        app.MapHub<ChatHub>(mainPath);
        return app;
    }
}
