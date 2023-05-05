using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnimalShelter.Model
{
    public class Shelter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual List<Animal>? Animals { get; set; }

    }
}
