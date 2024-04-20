using System.ComponentModel.DataAnnotations.Schema;

namespace Musicalog.Data.Models;

public abstract class Entity
{
    public int Id { get; set; }
}