using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XnesServer.Models;

namespace XnesServer.Interfaces
{
    public interface IXnesService
    {
        Customers GetCustomer(string tz);
        void AddCustomer(Customers customer);
        List<Customers> GetAllCustomers();
        List<Cities> GetAllCities();
    }
}
