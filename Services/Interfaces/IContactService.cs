using DomainModels;

namespace Services.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetContactsAsync(int pageNumber, int pageSize);
        // Other methods related to contact management can be defined here
        int GetTotalContactsCount();
    }
}
