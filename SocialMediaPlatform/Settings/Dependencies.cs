using Microsoft.EntityFrameworkCore;
using SocialMediaPlatform.DBContext;
using SocialMediaPlatform.Repositories;
using SocialMediaPlatform.Services;

namespace SocialMediaPlatform.Settings
{
    public class Dependencies
    {
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();
            
            applicationBuilder.Services.AddDbContext<SocialMediaPlatformContext>(
                options => options.UseSqlServer(
                    applicationBuilder.Configuration.GetConnectionString("DefaultConnection")
                    ));

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IPostService, PostService>();

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
        }
    }
}
