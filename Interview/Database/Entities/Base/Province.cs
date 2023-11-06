using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.Database.Entities.Base
{
    [Table(name: nameof(Province) , Schema = Schema.Base)]
    public class Province : Entity
    {
        public string? Name { get; set; }
    }
}
