using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShopApp.Core.Filter;

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

        public List<Pet> ReadPets(Filter filter)
        {
           IEnumerable<Pet> filtering = FakeDb.Pets;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "Name":
                        filtering = filtering.Where(p => p.Name.Contains(filter.SearchText));
                        break;
                   
                }
            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Pet).GetProperty(filter.OrderProperty);
                if (prop == null)
                {
                    throw new InvalidDataException("Wrong OrderProperty input," +
                                                   " OrderProperty has to match to corresponding pet property");
                }

                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(p => prop.GetValue(p, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }

            
            return filtering.ToList();
        }

        public Pet RemovePet(int id)
        {
            Pet petToDelete = FakeDb.Pets.Find(x => x.PetId.Equals(id));
            if (FakeDb.RemovePet(id) == false)
            {
                return null;
            }
            return petToDelete;
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
