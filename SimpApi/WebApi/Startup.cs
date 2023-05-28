using Business.DependencyResolver;
using Business.Extensions;
using Business.ValidationRules;
using Core.Extensions;
using DataAccess.Contexts;
using Entities.Concrete;
using Entities.Models;
using FluentValidation;

namespace WebApi;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IValidator<ProductModel>, ProductModelValidator>();
        services.AddScoped<IValidator<CategoryModel>, CategoryModelValidator>();
        services.AddCustomSwaggerExtension();
        services.AddMapperExtension();
        services.AddRepositoryResolver();

    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelsExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sim Company");
            c.DocumentTitle = "SimApi Company";
        });

        app.UseHttpsRedirection();

        // add auth 
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
