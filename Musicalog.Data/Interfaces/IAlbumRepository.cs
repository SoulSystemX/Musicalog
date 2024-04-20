using Musicalog.Data.Entities;

namespace Musicalog.Data.Interfaces;

public interface IAlbumRepository
{
    Task<IEnumerable<Album>> GetAlbums();
    Task<Album> GetAlbum(int id);
    Task AddAlbum(Album album);
    Task UpdateAlbum(Album album);
    Task DeleteAlbum(int id);
}