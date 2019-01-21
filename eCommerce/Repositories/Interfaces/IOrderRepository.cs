using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IOrderRepository
    {
        //Create
        Order Add(Guid orderId);

        //Read
        List<Order> GetOrder(Guid ClientId);

        //Update
        Order Update(Guid OrderId, Order order);
        Order UpdateDeliveryDate(Guid OrderId, DateTime DeliveryDate);
        Order UpdateStatus(Guid OrderId, Status Status);
        Order UpdatePayment(Guid OrderId, bool Payment);

        //Delete
        bool Delete(Guid OrderId);

    }
}
