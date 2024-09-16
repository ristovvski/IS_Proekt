using IS_Proekt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PetStore
{
    public class Shelter : BaseEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<Pet>? Pets { get; set; }

    }
}
