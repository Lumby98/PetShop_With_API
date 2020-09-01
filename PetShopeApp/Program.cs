using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Infrastructure.Data;
using System;

namespace PetShopApp.UI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IPetRepository petRepository = new PetRepository();
            petRepository.InitData();
            IPetService petService = new PetService(petRepository);
            var printer = new Printer(petRepository);
            var p = new Program();

            var menuSelection = printer.ShowMenu();
            int selection;

            while (menuSelection != 8)
            {
                switch(menuSelection)
                {
                    case 1:
                        printer.ListAllPets();
                        p.ReturnMenu();
                        break;
                    case 2:
                        printer.search();
                        p.ReturnMenu();
                        break;
                    case 3:
                        printer.CreatePet();
                        p.ReturnMenu();
                        break;
                    case 4:
                        printer.DeletePet();
                        p.ReturnMenu();
                        break;
                    case 5:
                        printer.UpdatePet();
                        p.ReturnMenu();
                        break;
                    case 6:
                        printer.SortByPrice();
                        p.ReturnMenu();
                        break;
                    case 7:
                        printer.FiveCheapest();
                        p.ReturnMenu();
                        break;
                    default:
                        break;
                }

                Console.Clear();
                menuSelection = printer.ShowMenu();
            }
            Console.WriteLine("Have a nice day");

            Console.ReadLine();
        }

        public void ReturnMenu()
        {
            int selection;
            Console.WriteLine("\nPlease press 1 to return to main menu");
            while (!int.TryParse(Console.ReadLine(), out selection) || selection != 1)
            {
                Console.WriteLine("please press 1 to go back to main menu");
            }
        }
    }
}
