using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        public List<Pet> GetPets(Filter.Filter filter);
        public Pet CreatePet(Pet pet);
        public Pet DeletePet(int id);
        public Pet GetPet(int id);
        public Pet UpdatePet(int id, Pet pet);
    }


}
