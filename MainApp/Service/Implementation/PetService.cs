using Domain.PetStore;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public IEnumerable<Pet> GetAllAvaliablePets()
        {
            return _petRepository.GetAll().Where(p => p.Status == PetStatus.NotAdopted);
        }
    }
}
