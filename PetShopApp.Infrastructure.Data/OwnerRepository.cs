using PetShopApp.Core.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShopApp.Core.Entities;
using PetShopApp.Core.Filter;

namespace PetShopApp.Infrastructure.Data
{
    public class OwnerRepository: IOwnerRepository
    {
        public List<Owner> ReadOwners()
        {
            var returnOwners = new List<Owner>(FakeDb.Owners);
            
            return returnOwners;
        }
        public List<Owner> ReadOwners(Filter filter)
        {
            IEnumerable<Owner> filtering = FakeDb.Owners;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "firstname":
                        filtering = filtering.Where(o => o.FirstName.Contains(filter.SearchText));
                        break;

                }
            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Owner).GetProperty(filter.OrderProperty);
                if (prop == null)
                {
                    throw new InvalidDataException("Wrong OrderProperty input," +
                                                   " OrderProperty has to match to corresponding owner property");
                }

                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(o => prop.GetValue(o, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }


            return filtering.ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            return FakeDb.AddOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            Owner ownerToDelete = FakeDb.Owners.Find(x => x.Id.Equals(id));
            if (FakeDb.RemoveOwner(id) == false)
            {
                return null;
            }
            return ownerToDelete;
        }

        public Owner getOwner(int id)
        {
            Owner returnOwner = FakeDb.Owners.Find(o => o.Id.Equals(id));
            return returnOwner;
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            Owner ownerToEdit = FakeDb.Owners.Find(o => o.Id.Equals(id));
            ownerToEdit.FirstName = owner.FirstName;
            ownerToEdit.LastName = owner.LastName;
            ownerToEdit.BirthDate = owner.BirthDate;
            ownerToEdit.Address = owner.Address;
            return ownerToEdit;
        }
    }
}
