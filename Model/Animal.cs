using System.Text.Json.Serialization;

namespace AnimalShelter.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Breed { get; set; } = string.Empty;

        public int NumberOfLegs { get; set; }

        public int ShelterId { get; set; }
        [JsonIgnore]
        public virtual Shelter? Shelter { get; set; }

    }
}
