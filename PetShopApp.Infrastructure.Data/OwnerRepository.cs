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
            return FakeDB.Owners;
        }

        public Owner CreateOwner(Owner owner)
        {
            return FakeDB.AddOwner(owner);
        }

        public bool DeleteOwner(int id)
        {
            return FakeDB.RemoveOwner(id);
        }

        public Owner getOwner(int id)
        {
            Owner returnOwner = FakeDB.Owners.Find(o => o.Id.Equals(id));
            return returnOwner;
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            Owner ownerToEdit = FakeDB.Owners.Find(o => o.Id.Equals(id));
            ownerToEdit.FirstName = owner.FirstName;
            ownerToEdit.LastName = owner.LastName;
            ownerToEdit.BirthDate = owner.BirthDate;
            ownerToEdit.Address = owner.Address;
            return ownerToEdit;
        }
    }
}
