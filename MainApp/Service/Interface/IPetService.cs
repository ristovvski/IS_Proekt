using Domain.PetStore;
using IS_Proekt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAllAvaliablePets();
    }
}
