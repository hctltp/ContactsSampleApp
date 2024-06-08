using DomainModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ContactService : IContactService
    {
        public async Task<List<Contact>> GetContactsAsync(int pageNumber, int pageSize)
        {
            var allContacts = GetAllContacts();
            var contacts = allContacts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            await Task.CompletedTask; // Simulate asynchronous operation
            return contacts;
        }

        public int GetTotalContactsCount()
        {
            return GetAllContacts().Count;
        }

        // Simulated data source
        private List<Contact> GetAllContacts()
        {
            // Generate some sample data
            var contacts = new List<Contact>();
            for (int i = 1; i <= 37; i++)
            {
                contacts.Add(new Contact
                {
                    Id = i,
                    Name = $"Contact {i}",
                    Email = $"contact{i}@example.com",
                    Phone = $"555-010{i:D2}",
                    ImageUrl = $"/images/contact-images/contact ({i}).jpg"
                });
            }
            return contacts;
        }
    }
}
