using System;
using System.Collections.Generic;
using Model;
using Model.Model;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ECommerceDbContext _context;
        public AddressRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        //Create
        public Address Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }

        //Read
        public Address GetAddress(User user)
        {
            return _context.Addresses.Find(user);

        }

        //Update
        public Address Update(User user, Address address)
        {
            var old = _context.Addresses.Find(user);
            var newM = _context.Addresses.Update(old);


            if (newM.Entity.User == user)
            {
                newM.Entity.Number = address.Number;
                newM.Entity.City = address.City;
                newM.Entity.Country = address.Country;
                newM.Entity.PostCode = address.PostCode;
                newM.Entity.Street = address.Street;
                newM.Entity.Number = address.Number;
                _context.SaveChanges();
                return newM.Entity;
            }
            return null;
        }

        //Delete
        public bool Delete(Guid id)
        {
            if (this._context.Addresses.Find(id) != null)
            {
                _context.Addresses.Remove(_context.Addresses.Find(id));
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
