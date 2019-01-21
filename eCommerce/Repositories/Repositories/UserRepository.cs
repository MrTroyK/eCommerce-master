using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Model;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceDbContext _context;

        public UserRepository(ECommerceDbContext context)
        {
            this._context = context;
        }

        //Create
        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.Addresses.Add(user.Address);
            _context.SaveChanges();
            return user;
        }

        //Read
        public User GetOne(string mail)
        {
            User user = _context.Users.SingleOrDefault(x => x.Mail == mail);
            return user;
        }

        public bool CheckExist(string mail, string password)
        {
            User userDB = this._context.Users.SingleOrDefault(x => x.Mail == mail && x.Password == password);
            return (userDB == null) ;
        }


        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }


        //Delete
        public bool Delete(Guid id)
        {
            if (_context.Users.Find(id) != null)
            {
                _context.Users.Remove(_context.Users.Find(id));
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
