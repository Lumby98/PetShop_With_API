using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        public Pet CreatePet(Pet pet);
        public bool DeletePet(int id);
    }


}
