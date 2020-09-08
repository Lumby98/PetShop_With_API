using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class OwnerService: IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwners();
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public bool DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }

        public Owner GetOwner(int id)
        {
            return _ownerRepository.getOwner(id);
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            return _ownerRepository.UpdateOwner(id, owner);
        }
    }
}
