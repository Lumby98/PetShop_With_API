using PetShopApp.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Infrastructure.Data
{
    public class OwnerRepository: IOwnerRepository
    {
        public List<Owner> ReadOwners()
        {
            var returnOwners = new List<Owner>(FakeDb.Owners);
            
            return returnOwners;
        }

        public Owner CreateOwner(Owner owner)
        {
            return FakeDb.AddOwner(owner);
        }

        public bool DeleteOwner(int id)
        {
            return FakeDb.RemoveOwner(id);
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
