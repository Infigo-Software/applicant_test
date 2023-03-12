using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Domain.Models.CommentModels;

using CMSPlus.Domain.Persistance;
using CMSPlus.Presentation.AutoMapperProfiles;
using CMSPlus.Presentation.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace CMSPlus.Presentation;

public static class Configurator
{
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddRazorPages().AddRazorRuntimeCompilation();
        
        services.AddScoped<TopicValidatorHelpers>();
        services.AddScoped<CommentValidatorHelpers>();


        services.AddScoped<IValidator<TopicCreateModel>, TopicCreateModelValidator>();
        services.AddScoped<IValidator<TopicEditModel>, TopicEditModelValidator>();

        services.AddScoped<IValidator<CommentCreateModel>, CommentCreateModelValidator>();


        services.AddControllersWithViews();

        services.AddValidatorsFromAssemblyContaining<TopicEditModelValidator>();
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddControllersWithViews();
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            //todo read via reflection
            cfg.AddProfile<TopicProfile>();
            cfg.AddProfile<CommentProfile>();

        }, typeof(Program).Assembly);
    }
}