using SocialMediaPlatform.DBContext;

namespace SocialMediaPlatform.Repositories
{
    public class BaseRepository
    {
        public readonly SocialMediaPlatformContext _socialMediaPlatformContext;

        public BaseRepository(SocialMediaPlatformContext socialMediaPlatformContext)
        {
            _socialMediaPlatformContext = socialMediaPlatformContext;
        }
    }
}
