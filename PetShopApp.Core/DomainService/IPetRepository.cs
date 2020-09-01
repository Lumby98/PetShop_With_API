using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IPetRepository
    {
        public List<Pet> ReadPets();
        public void InitData();
        public Pet AddPet(Pet pet);

        public bool RemovePet(int id);

    }
}
