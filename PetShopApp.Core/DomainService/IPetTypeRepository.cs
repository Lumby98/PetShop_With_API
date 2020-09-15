using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.DomainService
{
    public interface IPetTypeRepository
    {
        public List<PetType> ReadPetTypes();
        public List<PetType> ReadPetTypes(Filter.Filter filter);
        public PetType CreatePetType(PetType type);
        public PetType DeletePetType(int id);
        public PetType GetPetType(int id);
        public PetType UpdatePetType(int id, PetType type);
    }
}
