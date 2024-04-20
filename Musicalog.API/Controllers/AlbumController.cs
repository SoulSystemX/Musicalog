using Microsoft.AspNetCore.Mvc;
using Musicalog.API.Configuration;
using Musicalog.Core.Interfaces;
using Musicalog.Data.Entities;

namespace Musicalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumController(IAlbumService albumService, IConfiguration configuration)
{
    [HttpGet("getAlbums")]
    [Produces("application/json")]
    public async Task<IEnumerable<Album>> GetAlbums()
    {
        return await albumService.GetAlbums();
    }
    
    [HttpGet("listAlbums")]
    [Produces("application/json")]
    //Listing with pagination
    public async Task<IEnumerable<Album>> ListAlbums(int? page)
    {
        MusicalogConfiguration musicalogConfiguration = new();
        configuration.GetSection("Musicalog").Bind(musicalogConfiguration);
        
        var albums =  await albumService.GetAlbums();
        
        var paginatedAlbums = albums.Skip((page ?? 0) * musicalogConfiguration.PageSize )
            .Take(musicalogConfiguration.PageSize)
            .ToList();

        return paginatedAlbums;
    }

    [HttpGet("getAlbum")]
    [Produces("application/json")]
    public async Task<Album> GetAlbum(int id)
    {
        return await albumService.GetAlbum(id);
    }


    [HttpPost("addAlbum")]
    [Produces("application/json")]
    public async Task AddAlbum(Album album)
    {
        await albumService.AddAlbum(album);
    }
    
    [HttpPut("updateAlbum")]
    [Produces("application/json")]
    public async Task UpdateAlbum(Album album)
    {
        await albumService.UpdateAlbum(album);
    }
    
    [HttpDelete("deleteAlbum")]
    [Produces("application/json")]
    public async Task DeleteAlbum(int id)
    {
        await albumService.DeleteAlbum(id);
    }
}