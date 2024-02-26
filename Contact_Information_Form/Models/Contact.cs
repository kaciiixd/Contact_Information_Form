using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Information_Form.Models
{
    // Define a class named 'Contact' to represent contact information
    public class Contact
    {
        // Constructor to initialize the properties of the 'Contact' class
        public Contact(string? name, string? lastName, string? email, string? rc, DateTime birthDate, string? gender, string? state, bool gdprConsent)
        {
            // Assign values to the properties using the constructor parameters
            Name = name;
            LastName = lastName;
            Email = email;
            RC = rc;
            BirthDate = birthDate;
            Gender = gender;
            State = state;
            GDPRConsent = gdprConsent;
        }

        // Properties to store contact information
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RC { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public bool GDPRConsent { get; set; }
    }
}
