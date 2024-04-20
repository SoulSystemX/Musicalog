using Musicalog.Data.Models;

namespace Musicalog.Data.Entities;

public class Album : Entity
{
    public string Name { get; init; }
    public DateTime ReleaseDate { get; init; }
    public string Genre { get; init; }
    public string Artist { get; init; }
}