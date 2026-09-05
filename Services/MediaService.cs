using MediaValidators.Mapping;

namespace MediaValidators.Services
{
    public interface IMediaService
    {
        Task<MediaDto> GetByIdAsync(int id);
        Task<List<MediaDto>> GetAllAsync();
        Task<MediaDto> CreateAsync(CreateMediaDto dto);
        Task<MediaDto> UpdateAsync(int id, UpdateMediaDto dto);
        Task<bool> DeleteAsync(int id);
    }

    public class MediaService : IMediaService
    {
        public Task<MediaDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MediaDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MediaDto> CreateAsync(CreateMediaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<MediaDto> UpdateAsync(int id, UpdateMediaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
