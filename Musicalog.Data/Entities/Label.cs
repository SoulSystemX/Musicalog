using Musicalog.Data.Models;

namespace Musicalog.Data.Entities;

public class Label : Entity
{
    public string Name { get; init; }
    public string Artist { get; init; }
}