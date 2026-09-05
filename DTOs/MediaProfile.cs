using AutoMapper;

namespace MediaValidators.Mapping
{
    // Domain entity
    public class Media
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; }
    }

    // DTO returned to clients
    public class MediaDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; }
    }

    // DTO used when creating a new media record
    public class CreateMediaDto
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
    }

    // DTO used when updating an existing media record
    public class UpdateMediaDto
    {
        public string FileName { get; set; }
    }

    public class MediaProfile : Profile
    {
        public MediaProfile()
        {
            // Entity to DTO (e.g. building the FilePath into a public Url)
            CreateMap<Media, MediaDto>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => "/media/" + src.FilePath));

            // Create DTO to Entity
            CreateMap<CreateMediaDto, Media>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UploadedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            // Update DTO to Entity (only overwrites FileName, ignores nulls for the rest)
            CreateMap<UpdateMediaDto, Media>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
