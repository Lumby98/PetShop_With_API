using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Data
{
    public static class FakeDb
    {
        public static List<Pet> Pets;
        public static List<Owner> Owners;
        public static List<PetType> PetTypes;
        public static int PetId = 1;
        public static int OwnerId = 1;
        public static int PetTypeId = 1;

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

          PetTypes = new List<PetType>{new PetType()
              {
                  PetTypeId = PetTypeId++,
                  PetTypeName = "dog"
              }, 
              new PetType()
              {
                  PetTypeId = PetTypeId++,
                  PetTypeName = "cat"
              },
              new PetType()
              {
                  PetTypeId = PetTypeId++,
                  PetTypeName = "goat"
              }

          };
          
           Pets = new List<Pet>{new Pet
                {
                    PetId = PetId++,
                    Name = "Spark",
                    PetType = PetTypes.Find(t => t.PetTypeId.Equals(1)),
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
                    PetType = PetTypes.Find(t => t.PetTypeId.Equals(2)),
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
                    PetType = PetTypes.Find(t => t.PetTypeId.Equals(3)),
                    BirthDate = DateTime.Now.AddYears(-666),
                    SoldDate = DateTime.Now.AddYears(-69),
                    Colour = "Black",
                    PreviousOwner = Owners.Find(o => o.Id.Equals(1)),
                    Price = 4999.95
                }, new Pet
            {
                PetId = PetId++,
                Name = "Dog",
                PetType = PetTypes.Find(t => t.PetTypeId.Equals(2)),
                BirthDate = DateTime.Now.AddYears(-666),
                SoldDate = DateTime.Now.AddYears(-100),
                Colour = "White",
                PreviousOwner = Owners.Find(o => o.Id.Equals(2)),
                Price = 4999.95
            }, new Pet
            {
                PetId = PetId++,
                Name = "allah",
                PetType = PetTypes.Find(t => t.PetTypeId.Equals(3)),
                BirthDate = DateTime.Now.AddYears(-1000),
                SoldDate = DateTime.Now.AddYears(-5),
                Colour = "white",
                PreviousOwner = Owners.Find(o => o.Id.Equals(1)),
                Price = 1000000000000000000000000000.00
            }
           };
           foreach (var owner in Owners)
           {
               owner.pets = new List<Pet>(Pets.FindAll(p =>
                   p.PreviousOwner.Id.Equals(owner.Id)));
           }

           foreach (var petType in PetTypes)
           {
               petType.Pets = new List<Pet>(Pets.FindAll(p =>
                   p.PetType.PetTypeId.Equals(petType.PetTypeId)));
           }
        }

      public static Pet AddPet(Pet pet)
        {
            pet.PetId = PetId++;
            Pets.Add(pet);
            return pet;
        }
      public static Owner AddOwner(Owner owner)
      {
          owner.Id = OwnerId++;
          Owners.Add(owner);
          return owner;
      }
      public static PetType AddPetType(PetType type)
      {
          type.PetTypeId = PetTypeId++;
          PetTypes.Add(type);
          return type;
      }

      public static bool RemovePet(int id)
        {
            if (Pets.Find(x => x.PetId == id) != null)
            {
               Pets.Remove(Pets.Find(x => x.PetId == id));
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
      public static bool RemovePetType(int id)
      {
          PetType petTypeDelete = PetTypes.Find(x => x.PetTypeId == id);

          if (petTypeDelete != null)
          {
              foreach (var pet in petTypeDelete.Pets)
              {
                  RemovePet(pet.PetId);
              }
              PetTypes.Remove(petTypeDelete);
             
              return true;
          }
          else
          {
              return false;
          }
      }

    }
}
