using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            Pet petAdd;
            if (pet == null)
            {
                throw new InvalidDataException("missing pet to add");
            }
            else if (pet.Name.Length < 1)
            {
                throw new InvalidDataException("pet name is to short");
            }

            petAdd = _petRepository.AddPet(pet);
            if (petAdd == null)
            {
                throw new DataException("could not add pet");
            }
            return petAdd;
        }

        public Pet DeletePet(int id)
        {
            if (!_petRepository.ReadPets().Exists(x => x.PetId.Equals(id)))
            {
                throw new KeyNotFoundException("pet could not be deleted");
            }

            return _petRepository.RemovePet(id);
        }

        public Pet GetPet(int id)
        {
            if (!_petRepository.ReadPets().Exists(x => x.PetId.Equals(id)))
            {
                throw new KeyNotFoundException("pet could not be found");
            }

            return _petRepository.FindPet(id);
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            if(!_petRepository.ReadPets().Exists(x => x.PetId == id))
            {
                throw new InvalidDataException("could not find pet to update");
            } else
            {
                return _petRepository.UpdatePet(id, pet);
            }
            
        }


        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets();
        }

        public List<Pet> GetPets(Filter.Filter filter)
        {
            return _petRepository.ReadPets(filter);
        }
    }
}
