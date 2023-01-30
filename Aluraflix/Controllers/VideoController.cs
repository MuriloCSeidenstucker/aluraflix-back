using Aluraflix.Data;
using Aluraflix.Data.Dtos.VideoDto;
using Aluraflix.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aluraflix.Controllers;

[ApiController]
[Route("[controller]")]
public class VideosController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public VideosController(AppDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpPost]
	public IActionResult AddVideo([FromBody] CreateVideoDto videoDto)
	{
		Video video = _mapper.Map<Video>(videoDto);
		_context.Add(video);
		_context.SaveChanges();
		return CreatedAtAction(nameof(GetVideoById), new { Id = video.Id }, video);
	}

	[HttpGet]
    public IEnumerable<ReadVideoDto> GetVideos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadVideoDto>>(_context.Videos.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetVideoById(int id)
    {
        var video = _context.Videos.FirstOrDefault(movie => movie.Id == id);
		if (video == null) return NotFound();
		var videoDto = _mapper.Map<ReadVideoDto>(video);
		return Ok(videoDto);
    }

	[HttpPut("{id}")]
	public IActionResult UpdateVideo(int id, [FromBody] UpdateVideoDto videoDto)
	{
		var video = _context.Videos.FirstOrDefault(video => video.Id == id);
		if (video == null) return NotFound();
		_mapper.Map(videoDto, video);
		_context.SaveChanges();
		return NoContent();
	}
}
