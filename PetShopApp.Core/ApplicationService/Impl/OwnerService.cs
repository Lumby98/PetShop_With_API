using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            Owner ownerAdd;
            if (owner == null)
            {
                throw new InvalidDataException("missing owner to add");
            } else if (owner.FirstName.Length < 1)
            {
                throw new InvalidDataException("owners first name is to short");
            } else if (owner.LastName.Length < 1)
            {
                throw new InvalidDataException("owner last name is to short");
            }

            ownerAdd = _ownerRepository.CreateOwner(owner);
            if (ownerAdd == null)
            {
                throw new DataException("could not add owner");
            }
            return ownerAdd;
        }

        public Owner DeleteOwner(int id)
        {
            if (!_ownerRepository.ReadOwners().Exists(x => x.Id.Equals(id)))
            {
                throw new KeyNotFoundException("owner could not be found");
            }
            return _ownerRepository.DeleteOwner(id);
        }

        public Owner GetOwner(int id)
        {
            if (!_ownerRepository.ReadOwners().Exists(x => x.Id.Equals(id)))
            {
                throw new KeyNotFoundException("owner could not be found");
            }
            return _ownerRepository.getOwner(id);
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            if (!_ownerRepository.ReadOwners().Exists(x => x.Id.Equals(id)))
            {
                throw new KeyNotFoundException("owner could not be found");
            }
            return _ownerRepository.UpdateOwner(id, owner);
        }
    }
}
