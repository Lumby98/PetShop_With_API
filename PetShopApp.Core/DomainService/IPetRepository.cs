using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IPetRepository
    {
        public List<Pet> ReadPets();
        public List<Pet> ReadPets(Filter.Filter filter);
        public void InitData();
        public Pet AddPet(Pet pet);

        public Pet RemovePet(int id);

        public Pet UpdatePet(int id, Pet pet);

        public Pet FindPet(int id);

    }
}
