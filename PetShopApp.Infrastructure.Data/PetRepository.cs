using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public Pet AddPet(Pet pet)
        {
            return FakeDB.AddPet(pet);
        }

        public void InitData()
        {
            FakeDB.InitData();
        }

        public List<Pet> ReadPets()
        {
            return FakeDB.pets;
        }

        public bool RemovePet(int id)
        {
            return FakeDB.RemovePet(id);
        }

    }
}
