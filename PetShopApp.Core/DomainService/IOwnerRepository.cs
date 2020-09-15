using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        public List<Owner> ReadOwners();
        public List<Owner> ReadOwners(Filter.Filter filter);
        public Owner CreateOwner(Owner owner);
        public Owner DeleteOwner(int id);
        public Owner getOwner(int id);
        public Owner UpdateOwner(int id, Owner owner);
    }
}
