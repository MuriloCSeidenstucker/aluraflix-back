using Aluraflix.Data.Dtos.VideoDto;
using Aluraflix.Models;
using AutoMapper;

namespace Aluraflix.Profiles;

public class VideoProfile : Profile
{
	public VideoProfile()
	{
		CreateMap<CreateVideoDto, Video>();
		CreateMap<UpdateVideoDto, Video>();
		CreateMap<Video, ReadVideoDto>();
		CreateMap<Video, UpdateVideoDto>();
	}
}
