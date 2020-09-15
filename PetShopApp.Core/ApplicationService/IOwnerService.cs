using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        public List<Owner> GetOwners();
        public List<Owner> GetOwners(Filter.Filter filter);
        public Owner CreateOwner(Owner owner);
        public Owner DeleteOwner(int id);
        public Owner GetOwner(int id);
        public Owner UpdateOwner(int id, Owner owner);
    }
}
