using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        public List<Owner> ReadOwners();
        public Owner CreateOwner(Owner owner);
        public bool DeleteOwner(int id);
        public Owner getOwner(int id);
        public Owner UpdateOwner(int id, Owner owner);
    }
}
