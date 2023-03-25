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
            applicationBuilder.Services.AddEndpointsApiExplorer();
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
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ICommentService, CommentService>();
            services.AddSingleton<IPostService, PostService>();

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();
        }
    }
}
