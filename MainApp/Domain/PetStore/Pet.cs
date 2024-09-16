using IS_Proekt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PetStore
{
    public class Pet : BaseEntity
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public PetType Type { get; set; }
        public string? Breed { get; set; }
        public string? Sex { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
        public PetStatus Status { get; set; }
        public Guid? ShelterId { get; set; }
        public Shelter? Shelter { get; set; }
        public int Price { get; set; }
    }
}
