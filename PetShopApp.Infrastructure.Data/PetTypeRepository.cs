using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using PetShopApp.Core.Filter;

namespace PetShopApp.Infrastructure.Data
{
    public class PetTypeRepository: IPetTypeRepository
    {
        public List<PetType> ReadPetTypes()
        {
            return FakeDb.PetTypes;
        }

        public List<PetType> ReadPetTypes(Filter filter)
        {
            IEnumerable<PetType> filtering = FakeDb.PetTypes;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "Name":
                        filtering = filtering.Where(p => p.PetTypeName.Contains(filter.SearchText));
                        break;

                }
            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Pet).GetProperty(filter.OrderProperty);
                if (prop == null)
                {
                    throw new InvalidDataException("Wrong OrderProperty input," +
                                                   " OrderProperty has to match to corresponding pet type property");
                }

                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(p => prop.GetValue(p, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }


            return filtering.ToList();
        }

        public PetType CreatePetType(PetType type)
        {
            return FakeDb.AddPetType(type);
        }

        public PetType DeletePetType(int id)
        {
            PetType petTypeToDelete = FakeDb.PetTypes.Find(x => x.PetTypeId.Equals(id));
            if (FakeDb.RemovePetType(id) == false)
            {
                return null;
            }
            return petTypeToDelete;
        }

        public PetType GetPetType(int id)
        {
            PetType type = FakeDb.PetTypes.Find(x => x.PetTypeId.Equals(id));
            return type;
        }

        public PetType UpdatePetType(int id, PetType type)
        {
            PetType petTypeToEdit = FakeDb.PetTypes.Find(x => x.PetTypeId.Equals(id));
            petTypeToEdit.PetTypeName = type.PetTypeName;
            return petTypeToEdit;
        }
    }
}
