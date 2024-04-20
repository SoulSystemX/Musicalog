using Moq;
using Musicalog.Core.Services;
using Musicalog.Data.Entities;
using Musicalog.Data.Interfaces;

namespace Musicalog.Test;

public class AlbumServiceTests
{
    private static Mock<IAlbumRepository> MockAlbumRepository { get; set; }
    private static AlbumService AlbumService { get; set; }

    [SetUp]
    public void Setup()
    {
        MockAlbumRepository = new Mock<IAlbumRepository>();
        AlbumService = new AlbumService(MockAlbumRepository.Object);
    }

    [Test]
    public async Task GetAlbums_ShouldReturnAllAlbums()
    {
        //Arrange
        MockAlbumRepository
            .Setup(mar => mar.GetAlbums())
            .ReturnsAsync(new List<Album>
            {
                new()
                {
                    Artist = "Linkin Park",
                    Name = "Meteora",
                    Genre = "Rock",
                    ReleaseDate = new DateTime(2003, 03, 25)
                }
            });


        //Act
        var result = await AlbumService.GetAlbums();
        //Assert
        Assert.That(result.Count() == 1);
    }

    [Test]
    public async Task GetAlbum_ShouldReturnCorrectAlbum()
    {
        //Arrange
        MockAlbumRepository
            .Setup(mar => mar.GetAlbum(1))
            .ReturnsAsync(new Album
                {
                    Artist = "Linkin Park",
                    Name = "Meteora",
                    Genre = "Rock",
                    ReleaseDate = new DateTime(2003, 03, 25)
                }
            );

        //Act
        var result = await AlbumService.GetAlbum(1);
        //Assert
        Assert.That(result.Artist == "Linkin Park" && result.Name == "Meteora");
        
    }
}