using System.ComponentModel.DataAnnotations;

namespace ToDo.Data.Models.Common;

public class Entity
{
    [Key]
    public long Id { get; init; }
}