using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

       
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.AddPet(pet);
        }

        public bool DeletePet(int id)
        {
            return _petRepository.RemovePet(id);
        }


        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets();
        }
    }
}
