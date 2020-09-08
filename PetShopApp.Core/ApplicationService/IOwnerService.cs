using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        public List<Owner> GetOwners();
        public Owner CreateOwner(Owner owner);
        public bool DeleteOwner(int id);
        public Owner GetOwner(int id);
        public Owner UpdateOwner(int id, Owner owner);
    }
}
