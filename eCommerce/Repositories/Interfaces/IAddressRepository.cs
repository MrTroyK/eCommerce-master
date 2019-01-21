using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IAddressRepository
    {
        //Create
        Address Add(Address address);

        //Read
        Address GetAddress(User user);

        //Update
        Address Update(User user, Address address);    

        //Delete
        bool Delete(Guid id);
    }
}
