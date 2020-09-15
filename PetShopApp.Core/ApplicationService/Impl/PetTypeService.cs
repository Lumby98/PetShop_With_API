using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class PetTypeService: IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;

        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }
        public List<PetType> GetPetTypes()
        {
            return _petTypeRepository.ReadPetTypes();
        }

        public List<PetType> GetPetTypes(Filter.Filter filter)
        {
            return _petTypeRepository.ReadPetTypes(filter);
        }

        public PetType CreatePetType(PetType type)
        {
            PetType petTypeAdd;
            if (type == null)
            {
                throw new InvalidDataException("missing pet type to add");
            }
            else if (type.PetTypeName.Length < 1)
            {
                throw new InvalidDataException("pet type name is to short");
            }

            petTypeAdd = _petTypeRepository.CreatePetType(type);
            if (petTypeAdd == null)
            {
                throw new DataException("could not add pet type");
            }

            return petTypeAdd;
        }

        public PetType DeletePetType(int id)
        {
            if (!_petTypeRepository.ReadPetTypes().Exists(x => x.PetTypeId.Equals(id)))
            {
                throw new KeyNotFoundException("pet type could not be deleted");
            }

            return _petTypeRepository.DeletePetType(id);
        }

        public PetType GetPetType(int id)
        {
            if (!_petTypeRepository.ReadPetTypes().Exists(x => x.PetTypeId.Equals(id)))
            {
                throw new KeyNotFoundException("could not get pet type");
            }

            return _petTypeRepository.GetPetType(id);
        }

        public PetType UpdatePetType(int id, PetType type)
        {
            if (!_petTypeRepository.ReadPetTypes().Exists(x => x.PetTypeId.Equals(id)))
            {
                throw new KeyNotFoundException("could not update pet type");
            }

            return _petTypeRepository.UpdatePetType(id, type);
        }
    }
}
