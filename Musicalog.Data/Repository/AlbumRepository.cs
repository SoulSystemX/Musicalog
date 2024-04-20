using Dapper;
using Musicalog.Data.Entities;
using Musicalog.Data.Interfaces;

namespace Musicalog.Data.Repository;

public class AlbumRepository(IUnitOfWork unitOfWork) : IAlbumRepository
{
    public async Task<IEnumerable<Album>> GetAlbums()
    {
        var sql = "SELECT * FROM Album";
        await unitOfWork.Connection.OpenAsync();
        await unitOfWork.BeginAsync();
        var result = await unitOfWork.Connection.QueryAsync<Album>(sql, transaction: unitOfWork.Transaction);

        await unitOfWork.CommitAsync();
        await unitOfWork.Connection.CloseAsync();
        return result;
    }

    public async Task<Album> GetAlbum(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        var sql = "SELECT * FROM Album WHERE Id=@id";
        await unitOfWork.Connection.OpenAsync();
        await unitOfWork.BeginAsync();
        var result = await unitOfWork.Connection.QueryAsync<Album>(sql, parameters, unitOfWork.Transaction);

        await unitOfWork.CommitAsync();
        await unitOfWork.Connection.CloseAsync();
        return result.First();
    }

    public async Task AddAlbum(Album album)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Name", album.Name);
        parameters.Add("Artist", album.Artist);
        parameters.Add("Genre", album.Genre);
        parameters.Add("ReleaseDate", album.ReleaseDate);

        var sql = "INSERT INTO Album (Name, Artist,Genre, ReleaseDate ) VALUES (@Name, @Artist, @Genre, @ReleaseDate)";

        await unitOfWork.Connection.OpenAsync();
        await unitOfWork.BeginAsync();
        await unitOfWork.Connection.QueryAsync<Album>(sql, parameters, unitOfWork.Transaction);

        await unitOfWork.CommitAsync();
        await unitOfWork.Connection.CloseAsync();

    }

    public async Task DeleteAlbum(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        
        var sql = @"
            DELETE FROM Album
            WHERE Id=@id";
        
        await unitOfWork.Connection.OpenAsync();
        await unitOfWork.BeginAsync();
        await unitOfWork.Connection.QueryAsync<Album>(sql, parameters, unitOfWork.Transaction);

        await unitOfWork.CommitAsync();
        await unitOfWork.Connection.CloseAsync();
    }

    public async Task UpdateAlbum(Album album)
    {
        var parameters = new DynamicParameters();
        
        parameters.Add("Id", album.Id);
        parameters.Add("Name", album.Name);
        parameters.Add("Artist", album.Artist);
        parameters.Add("Genre", album.Genre);
        parameters.Add("ReleaseDate", album.ReleaseDate);
        
        var sql = @"
            UPDATE Album
            SET Name = @Name
            ,Genre = @Genre
            ,ReleaseDate = @ReleaseDate
            ,Artist = @Artist
            WHERE Id=@id";

        await unitOfWork.Connection.OpenAsync();
        await unitOfWork.BeginAsync();
        await unitOfWork.Connection.QueryAsync<Album>(sql, parameters, unitOfWork.Transaction);

        await unitOfWork.CommitAsync();
        await unitOfWork.Connection.CloseAsync();
    }
}