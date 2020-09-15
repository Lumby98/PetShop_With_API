using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
    public class PetType
    {
        public int PetTypeId { get; set; }
        public string PetTypeName { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
