using Musicalog.Core.Interfaces;
using Musicalog.Data.Entities;
using Musicalog.Data.Interfaces;

namespace Musicalog.Core.Services;

public class AlbumService(IAlbumRepository albumRepository) : IAlbumService
{
    public async Task<IEnumerable<Album>> GetAlbums()
    {
        return await albumRepository.GetAlbums();
    }

    public async Task<Album> GetAlbum(int id)
    {
        return await albumRepository.GetAlbum(id);
    }

    public async Task AddAlbum(Album album)
    {
        await albumRepository.AddAlbum(album);
    }

    public async Task UpdateAlbum(Album album)
    {
        await albumRepository.UpdateAlbum(album);
    }

    public async Task DeleteAlbum(int id)
    {
        await albumRepository.DeleteAlbum(id);
    }
}