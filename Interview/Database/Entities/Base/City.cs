using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.Database.Entities.Base
{
    [Table(name: nameof(City) , Schema = Schema.Base)]
    public class City : Entity
    {
        public string? Name { get; set; }
        public long ProvinceId { get; set; }
    }
}
