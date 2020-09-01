using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.UI
{
    public class Printer
    {
        IPetService _PetService;
        readonly String[] MenuItems = {
                "List of pets",
                "Search",
                "Create pet",
                "Delete pet",
                "Update pet",
                "Sort pets by price",
                "show 5 cheapest perst",
                "Exit"
            };

        public Printer(IPetRepository petRepository)
        {
            _PetService = new PetService(petRepository);
        }
        public int ShowMenu()
        {
            Console.WriteLine("Select what you want to do:\n");

            for (int i = 0; i < MenuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {MenuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1 ||
                selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;
        }
        public void ListAllPets()
        {
            List<Pet> pets = _PetService.GetPets();
            Console.WriteLine("Showing list of pets");

            foreach (var pet in pets)
            {
                Console.WriteLine(pet.ToString());
            }
        }
        public void search()
        {
            Console.WriteLine("please select the type of pet you want\n");
            Console.WriteLine("1: Dog");
            Console.WriteLine("2: Cat");
            Console.WriteLine("3: Goat");

            int s;
            while (!int.TryParse(Console.ReadLine(), out s) || s < 1 || s > 3)
            {
                Console.WriteLine("please select a number between 1-3");
            }
            List<Pet> pets = _PetService.GetPets();
            List<Pet> searchPet;

            if(s.Equals(1))
            {
                searchPet = pets.FindAll(pet => pet.PetType.Equals("Dog"));
            } else if(s.Equals(2)){
                searchPet = pets.FindAll(pet => pet.PetType.Equals("Cat"));
            }
            else
            {
                searchPet = pets.FindAll(pet => pet.PetType.Equals("Goat"));
            }

            foreach (var pet in searchPet)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(pet.ToString());
            }

        }
        public void CreatePet()
        {
            //pet name
            Console.WriteLine("--------------------------");
            Console.WriteLine("What is the pets name\n");
            string name = Console.ReadLine();

            //pet type
            Console.WriteLine("--------------------------");
            Console.WriteLine("What type of animale is the pet");
            Console.WriteLine("1: Dog");
            Console.WriteLine("2: Cat");
            Console.WriteLine("3: Goat");
            
            int s;
            while (!int.TryParse(Console.ReadLine(), out s) || s < 1 || s > 3)
            {
                Console.WriteLine("please select a number between 1-3");
            }

            string petType;
            if(s.Equals(1))
            {
                petType = "Dog";
            } else if(s.Equals(2))
            {
                petType = "cat";
            } else
            {
                petType = "goat";
            }

            //birthdate
            Console.WriteLine("--------------------------");
            Console.WriteLine("please enter the pets birthday (dd-mm-yyyy)");
            DateTime birthDate;
            while(!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.WriteLine("please write an actual date (dd-mm-yyyy");
            }

            //sold
            Console.WriteLine("--------------------------");
            Console.WriteLine("when was the pet sold (dd-mm-yyyy)");
            DateTime sold;
            while (!DateTime.TryParse(Console.ReadLine(), out sold))
            {
                Console.WriteLine("please write an actual date (dd-mm-yyyy");
            }

            //colour
            Console.WriteLine("--------------------------");
            Console.WriteLine("what Colour is your pet");
            string colour = Console.ReadLine();

            //previous owner
            Console.WriteLine("--------------------------");
            Console.WriteLine("what is the name of the previous owner");
            string owner = Console.ReadLine();

            //price
            Console.WriteLine("--------------------------");
            Console.WriteLine("what is the price of the pet");
                 double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("please enter a price for the pet, that is a number");
            }

            Pet newPet = new Pet
            {
                Name = name,
                PetType = petType,
                BirthDate = birthDate,
                SoldDate = sold,
                Colour = colour,
                PreviousOwner = owner,
                Price = price
            };
            _PetService.CreatePet(newPet);
            Console.WriteLine("--------------------------");
            Console.WriteLine($"pet with the name: {newPet.Name}");
            
        }
        public void DeletePet()
        {
            List<Pet> pets = _PetService.GetPets();
            Console.WriteLine("choose a pet to delete");

            foreach (var pet in pets)
            {
                Console.WriteLine(pet.ToString());
            }

            int id;
            while(!int.TryParse(Console.ReadLine(), out id) || id < 0 || id > pets.Count)
            {
                Console.WriteLine("please chose a valied id");
            }
            
            if(!_PetService.DeletePet(id))
            {
                Console.WriteLine("something went wrong");
            }
            else
            {
                Console.WriteLine($"pet with the id: {id} was deleted");
            }
        }
        public void UpdatePet()
        {
            ListAllPets();
            Console.WriteLine("chose a pet by id");
            int s;
            while (!int.TryParse(Console.ReadLine(), out s) || _PetService.GetPets().Find(pet => pet.PetId.Equals(s)).Equals(null))
            {
                Console.WriteLine("please select a actual Id");
            }
            Pet newPet = _PetService.GetPets().Find(Pet => Pet.PetId.Equals(s));


            //pet name
            Console.WriteLine("--------------------------");
            Console.WriteLine("What is the pets name\n");
            string name = Console.ReadLine();

            //pet type
            Console.WriteLine("--------------------------");
            Console.WriteLine("What type of animal is the pet");
            Console.WriteLine("1: Dog");
            Console.WriteLine("2: Cat");
            Console.WriteLine("3: Goat");
            Console.WriteLine("4: not changed");

            int select;
            while ((!int.TryParse(Console.ReadLine(), out select) || select < 1 || select > 4))
            {
                Console.WriteLine("please select a number between 1-4");
            }

            string petType;
            if (s.Equals(1))
            {
                petType = "Dog";
            }
            else if (s.Equals(2))
            {
                petType = "cat";
            }
            else if(s.Equals(3))
            {
                petType = "goat";
            }
            else
            {
                petType = newPet.PetType;
            }

            //birthdate
            Console.WriteLine("--------------------------");
            Console.WriteLine("please enter the pets birthday (dd-mm-yyyy)");
            DateTime birthDate;
            var constant = Console.ReadLine();
            while (!DateTime.TryParse(constant, out birthDate) && !constant.Length.Equals(0))
            {
                Console.WriteLine("please write an actual date (dd-mm-yyyy)");
                constant = Console.ReadLine();
            }

            //sold
            Console.WriteLine("--------------------------");
            Console.WriteLine("when was the pet sold (dd-mm-yyyy)");
            DateTime sold;
            constant = Console.ReadLine();
            while (!DateTime.TryParse(constant, out sold) && !constant.Length.Equals(0))
            {
                Console.WriteLine("please write an actual date (dd-mm-yyyy");
                constant = Console.ReadLine();
            }

            //colour
            Console.WriteLine("--------------------------");
            Console.WriteLine("what Colour is your pet");
            string colour = Console.ReadLine();

            //previous owner
            Console.WriteLine("--------------------------");
            Console.WriteLine("what is the name of the previous owner");
            string owner = Console.ReadLine();

            //price
            Console.WriteLine("--------------------------");
            Console.WriteLine("what is the price of the pet");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price) && price.Equals(null))
            {
                Console.WriteLine("please enter a price for the pet, that is a number");
            }

            //editing
            if (!newPet.Name.Equals(name) && !name.Equals(""))
            {
                newPet.Name = name;
            }
            if (!newPet.PetType.Equals(petType))
            {
                newPet.PetType = petType;
            }
            if (!newPet.BirthDate.Equals(birthDate) && !birthDate.Equals(null))
            {
                newPet.BirthDate = birthDate;
            }
            if (!newPet.SoldDate.Equals(sold) && !sold.Equals(null))
            {
                newPet.SoldDate = sold;
            }
            if (!newPet.Colour.Equals(colour) && !colour.Equals(""))
            {
                newPet.Colour = colour;
            }
            if (!newPet.PreviousOwner.Equals(owner) && !owner.Equals(""))
            {
                newPet.PreviousOwner = owner;
            }
            if (!newPet.Price.Equals(price) && !price.Equals(0))
            {
                newPet.Price = price;
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine($"pet with id: {newPet.PetId} was updated");
            Console.WriteLine(newPet.ToString());
           
        }
        public void SortByPrice()
        {
            List<Pet> pets = _PetService.GetPets().OrderBy(pet => pet.Price).ToList();
            Console.WriteLine("Showing list of pets sorted by price");
            Console.WriteLine("--------------------------");

            foreach (var pet in pets)
            {
                Console.WriteLine(pet.ToString());
            }
        }
        public void FiveCheapest()
        {
            List<Pet> pets = _PetService.GetPets().OrderBy(pet => pet.Price).ToList();
            Console.WriteLine("Showing the five cheapest pets");
            Console.WriteLine("--------------------------");

            if (pets.Count < 5)
            {
                foreach (var pet in pets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(pets[i].ToString());
                }
            }

        }
    }
}
