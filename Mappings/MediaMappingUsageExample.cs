// 1. Register AutoMapper and the service in Program.cs
//    builder.Services.AddAutoMapper(typeof(MediaProfile));
//    builder.Services.AddScoped<IMediaService, MediaService>();

// 2. Inject IMapper and use it
using AutoMapper;
using MediaValidators.Mapping;

public class MediaService
{
    private readonly IMapper _mapper;

    public MediaService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public MediaDto ToDto(Media media)
    {
        return _mapper.Map<MediaDto>(media);
    }

    public Media FromCreateDto(CreateMediaDto dto)
    {
        return _mapper.Map<Media>(dto);
    }

    public void ApplyUpdate(UpdateMediaDto dto, Media existingMedia)
    {
        _mapper.Map(dto, existingMedia); // maps onto the existing object
    }
}
