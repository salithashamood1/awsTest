using Microsoft.Extensions.Options;
using MongoDB.Driver;
using testApi.model;
using testApi.Services;

namespace awsTest;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        //services.Configure<UserStoreDatabaseSettings>(Configuration);
        //services.AddSingleton<IUserStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<UserStoreDatabaseSettings>>().Value);
        //services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("UserStoreDatabaseSettings:ConnectionString")));
        //services.AddScoped<IUserService, UserService>();
        services.AddControllers();
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger().UseSwaggerUI(setup =>
        {
            string swaggerJsonBasePath = string.IsNullOrWhiteSpace(setup.RoutePrefix) ? "." : "..";
            setup.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Version 1.0");
            setup.OAuthAppName("Lambda Api");
            setup.OAuthScopeSeparator("");
            setup.OAuthUsePkce();
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}