using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string PetType { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Colour { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Id: {PetId} Name: {Name} Type: {PetType}" +
                    $" Birthdate: {BirthDate} Sold: {SoldDate} Colour: {Colour}" +
                    $" Last owner: {PreviousOwner} Price: {Price}";
        }
        
    }
}
