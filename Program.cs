using AdminService.DataModel;
using AdminService.Repository;
using AdminService.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using OpenTelemetry.Exporter;
using OpenTelemetry;
using AdminService.Model;
using AdminService.Extensions;

namespace AdminService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers()
                .AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;                   
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connection = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis") ?? "127.0.0.1:6379");
            builder.Services.AddSingleton<IConnectionMultiplexer>(connection);
            builder.Services.AddDbContext<AdminDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("cpqconnectionstring")));
            var tracingExporter = builder.Configuration.GetValue("UseTracingExporter", defaultValue: "console")!.ToLowerInvariant();
            // Build a resource configuration action to set service information.
            Action<ResourceBuilder> configureResource = r => r.AddService(
                serviceName: builder.Configuration.GetValue("ServiceName", defaultValue: "Admin-api")!,
                serviceVersion: typeof(Program).Assembly.GetName().Version?.ToString() ?? "unknown",
                serviceInstanceId: Environment.MachineName);
            // Configure OpenTelemetry tracing & metrics with auto-start using the
            // AddOpenTelemetry extension from OpenTelemetry.Extensions.Hosting.
            builder.Services.AddOpenTelemetry()
                .ConfigureResource(configureResource)
                .WithTracing(appBuilder =>
                {
                    // Tracing
                    // Ensure the TracerProvider subscribes to any custom ActivitySources.
                    appBuilder
                        .AddSource(Instrumentation.ActivitySourceName)
                        .AddHttpClientInstrumentation()
                        .AddAspNetCoreInstrumentation()
                        .AddRedisInstrumentation();

                    switch (tracingExporter)
                    {
                        case "otlp":
                            appBuilder.AddOtlpExporter(otlpOptions =>
                            {
                                // Use IConfiguration directly for Otlp exporter endpoint option.
                                otlpOptions.Endpoint = new Uri(builder.Configuration.GetValue("Otlp:Endpoint", defaultValue: "http://localhost:4317/api/traces")!);
                                otlpOptions.Protocol = OtlpExportProtocol.Grpc;
                                otlpOptions.ExportProcessorType = ExportProcessorType.Batch;
                            });
                            break;

                        default:
                            break;
                    }
                });
            builder.Services.AddTransient<IAdminService, Service.AdminService>();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            var app = builder.Build();
            app.UseCorrelationId();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}