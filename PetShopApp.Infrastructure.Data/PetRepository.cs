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

        public Pet UpdatePet(int id, Pet pet)
        {
            Pet petToEdit = FakeDB.pets.Find(pet => pet.PetId == id);
            petToEdit.Name = pet.Name;
            petToEdit.PetType = pet.PetType;
            petToEdit.BirthDate = pet.BirthDate;
            petToEdit.SoldDate = pet.SoldDate;
            petToEdit.Colour = pet.Colour;
            petToEdit.PreviousOwner = pet.PreviousOwner;
            petToEdit.Price = pet.Price;

            return petToEdit;
        }
    }
}
