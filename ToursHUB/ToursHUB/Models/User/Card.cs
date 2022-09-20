using System;
using System.Collections.Generic;
using System.Text;

namespace ToursHUB.Models.User
{
  public  class Card
    {


       
        public string CardNumber { get; set; }

       
        public string CardHolder { get; set; }

        
        public string CardSecurityNumber { get; set; }

       
        public string Address { get; set; }

     
        public string Country { get; set; }

     
        public string State { get; set; }

       
        public string Street { get; set; }

      
        public string ZipCode { get; set; }

      
        public string Email { get; set; }

    
        public bool EmailVerified { get; set; }

      
        public string PhoneNumber { get; set; }

  
        public bool PhoneNumberVerified { get; set; }
    }
}
