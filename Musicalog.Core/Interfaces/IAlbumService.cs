using Musicalog.Data.Entities;

namespace Musicalog.Core.Interfaces;

public interface IAlbumService
{
    public Task<IEnumerable<Album>> GetAlbums();
    public Task<Album> GetAlbum(int id);
    public Task AddAlbum(Album album);
    public Task UpdateAlbum(Album album);
    public Task DeleteAlbum(int id);
}