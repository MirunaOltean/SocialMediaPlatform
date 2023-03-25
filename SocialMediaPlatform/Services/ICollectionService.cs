
namespace SocialMediaPlatform.Services
{
    public interface ICollectionService<T>
    {
        Task<List<T>> GetAll();

        Task<T> Get(int id);

        Task<bool> Create(T model);

        Task<bool> Update(int id, T model);

        Task<bool> Delete(int id);

    }
}
