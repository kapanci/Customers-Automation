using DataAccsesLayer.Abstract;
using DataAccsess.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsesLayer.Concrete
{
    public class CustomerAddressDal : ICustomerAddressDal
    {
        private readonly AppDbContext _contextaddress;

        public CustomerAddressDal(AppDbContext context)
        {
            _contextaddress = context;
        }

        public void Add(CustomerAddress address)
        {
            _contextaddress.addresses.Add(address);
            _contextaddress.SaveChanges(); // Save changes to persist data
        }

        public void Delete(CustomerAddress address)
        {
            _contextaddress.addresses.Remove(address);
            _contextaddress.SaveChanges();
        }

        public CustomerAddress Get(int id)
        {
           return _contextaddress.addresses.FirstOrDefault(c => c.Id == id);   
        }

        public List<CustomerAddress> GetAll()
        {
            return _contextaddress.addresses.ToList();
        }

        public void Update(CustomerAddress address)
        {
            var existingAddress = _contextaddress.addresses.FirstOrDefault(a => a.Id == address.Id);
            if (existingAddress != null)
            {
                // Update existing address details
                existingAddress.AddressName = address.AddressName;
                existingAddress.City = address.City;
                existingAddress.District = address.District;
                existingAddress.Neighborhood = address.Neighborhood;
                existingAddress.Street = address.Street;
                existingAddress.BuildingNumber = address.BuildingNumber;
                existingAddress.ApartmentNumber = address.ApartmentNumber;
                existingAddress.PostalCode = address.PostalCode;
                existingAddress.FullAddress = address.FullAddress;
                existingAddress.CustomerId = address.CustomerId;

                // Save changes to the database
                _contextaddress.SaveChanges();
            }
        }
    }
}
