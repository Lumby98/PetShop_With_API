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
            return FakeDb.AddPet(pet);
        }

        public void InitData()
        {
            FakeDb.InitData();
        }

        public List<Pet> ReadPets()
        {
            return FakeDb.Pets;
        }

        public bool RemovePet(int id)
        {
            return FakeDb.RemovePet(id);
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            Pet petToEdit = FakeDb.Pets.Find(p => p.PetId == id);
            petToEdit.Name = pet.Name;
            petToEdit.PetType = pet.PetType;
            petToEdit.BirthDate = pet.BirthDate;
            petToEdit.SoldDate = pet.SoldDate;
            petToEdit.Colour = pet.Colour;
            petToEdit.PreviousOwner = pet.PreviousOwner;
            petToEdit.Price = pet.Price;

            return petToEdit;
        }

        public Pet FindPet(int id)
        {
            Pet returnPet = FakeDb.Pets.Find(p => p.PetId.Equals(id));
            return returnPet;
        }
    }
}
