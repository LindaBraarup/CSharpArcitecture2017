using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IOrderRepository
    {
        //C
        Order Create(Order order);
        //R
        List<Order> GetAll();
        Order Get(int Id);
        //U
        //Update is done in the UnitOfWork
        //D
        Order Delete(int Id);
    }
}
