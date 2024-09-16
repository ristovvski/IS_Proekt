using Domain.PetStore;
using IS_Proekt.Identity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class PetRepository : IPetRepository
    {
        private readonly PetStoreDbContext context;
        private DbSet<Pet> entities;
        public PetRepository(PetStoreDbContext context)
        {
            this.context = context;
            entities = context.Set<Pet>();
        }
        public IEnumerable<Pet> GetAll()
        {
            return entities.AsEnumerable();
        }
    }
}
