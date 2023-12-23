using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities
{
    public class Generation
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]

        public Model Model { get; set; }
    }
}
