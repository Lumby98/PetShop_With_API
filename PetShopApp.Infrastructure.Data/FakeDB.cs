using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Data
{
    public static class FakeDB
    {
        public static List<Pet> pets;
        public static int Id = 1;

      public static void InitData()
        {
           pets = new List<Pet>{new Pet
                {
                    PetId = Id++,
                    Name = "Spark",
                    PetType = "Dog",
                    BirthDate = DateTime.Now.AddYears(-5),
                    SoldDate = DateTime.Now.AddMonths(-1),
                    Colour = "Brown",
                    PreviousOwner = "Mark Hero",
                    Price = 4999.95
                },
                new Pet
                {
                    PetId = Id++,
                    Name = "Lilly",
                    PetType = "Cat",
                    BirthDate = DateTime.Now.AddYears(-7),
                    SoldDate = DateTime.Now,
                    Colour = "Grey",
                    PreviousOwner = "Mads Jensen",
                    Price = 1500
                 },
                new Pet
                {
                    PetId = Id++,
                    Name = "Lucifer",
                    PetType = "Goat",
                    BirthDate = DateTime.Now.AddYears(-666),
                    SoldDate = DateTime.Now.AddYears(-69),
                    Colour = "Black",
                    PreviousOwner = "God",
                    Price = 4999.95
                }, new Pet
            {
                PetId = Id++,
                Name = "Dog",
                PetType = "Cat",
                BirthDate = DateTime.Now.AddYears(-666),
                SoldDate = DateTime.Now.AddYears(-100),
                Colour = "White",
                PreviousOwner = "Michael Lund",
                Price = 4999.95
            }, new Pet
            {
                PetId = Id++,
                Name = "allah",
                PetType = "Goat",
                BirthDate = DateTime.Now.AddYears(-1000),
                SoldDate = DateTime.Now.AddYears(-5),
                Colour = "white",
                PreviousOwner = "Muhamed",
                Price = 1000000000000000000000000000.00
            }
           };
          
        }

      public static Pet AddPet(Pet pet)
        {
            pet.PetId = Id++;
            pets.Add(pet);
            return pet;
        }
      public static bool RemovePet(int id)
        {
            if (pets.Find(x => x.PetId == id) != null)
            {
               pets.Remove(pets.Find(x => x.PetId == id));
                return true;

            }
            else
            {
                return false;
            }
        }
  
    }
}
