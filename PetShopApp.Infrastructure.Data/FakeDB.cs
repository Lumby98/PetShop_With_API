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
        public static List<Owner> Owners;
        public static int PetId = 1;
        public static int OwnerId = 1;

      public static void InitData()
      {
          Owners = new List<Owner>{new Owner
              {
                  Id = OwnerId++,
                  FirstName = "Mark",
                  LastName = "Hero",
                  Address = "Kirkevej 3",
                  BirthDate = DateTime.Now.Date.AddYears(-35)
          },
              new Owner
              {
                  Id = OwnerId++,
                  FirstName = "Iliana",
                  LastName = "Veda",
                  Address = "EmeraldStreet 1",
                  BirthDate = DateTime.Now.Date.AddYears(-20)
              }
              };
          
           pets = new List<Pet>{new Pet
                {
                    PetId = PetId++,
                    Name = "Spark",
                    PetType = "Dog",
                    BirthDate = DateTime.Now.AddYears(-5),
                    SoldDate = DateTime.Now.AddMonths(-1),
                    Colour = "Brown",
                    PreviousOwner = Owners.Find(o => o.Id.Equals(2)),
                    Price = 4999.95
                },
                new Pet
                {
                    PetId = PetId++,
                    Name = "Lilly",
                    PetType = "Cat",
                    BirthDate = DateTime.Now.AddYears(-7),
                    SoldDate = DateTime.Now,
                    Colour = "Grey",
                    PreviousOwner = Owners.Find(o => o.Id.Equals(2)),
                    Price = 1500
                 },
                new Pet
                {
                    PetId = PetId++,
                    Name = "Lucifer",
                    PetType = "Goat",
                    BirthDate = DateTime.Now.AddYears(-666),
                    SoldDate = DateTime.Now.AddYears(-69),
                    Colour = "Black",
                    PreviousOwner = Owners.Find(o => o.Id.Equals(1)),
                    Price = 4999.95
                }, new Pet
            {
                PetId = PetId++,
                Name = "Dog",
                PetType = "Cat",
                BirthDate = DateTime.Now.AddYears(-666),
                SoldDate = DateTime.Now.AddYears(-100),
                Colour = "White",
                PreviousOwner = Owners.Find(o => o.Id.Equals(2)),
                Price = 4999.95
            }, new Pet
            {
                PetId = PetId++,
                Name = "allah",
                PetType = "Goat",
                BirthDate = DateTime.Now.AddYears(-1000),
                SoldDate = DateTime.Now.AddYears(-5),
                Colour = "white",
                PreviousOwner = Owners.Find(o => o.Id.Equals(1)),
                Price = 1000000000000000000000000000.00
            }
           };
          
        }

      public static Pet AddPet(Pet pet)
        {
            pet.PetId = PetId++;
            pets.Add(pet);
            return pet;
        }

      public static Owner AddOwner(Owner owner)
      {
          owner.Id = OwnerId++;
          Owners.Add(owner);
          return owner;
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

      public static bool RemoveOwner(int id)
      {
          if (Owners.Find(x => x.Id == id) != null)
          {
              Owners.Remove(Owners.Find(x => x.Id == id));
              return true;

          }
          else
          {
              return false;
          }
      }

    }
}
