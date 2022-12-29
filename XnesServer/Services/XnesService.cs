using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XnesServer.Interfaces;
using XnesServer.Models;

namespace XnesServer.Services
{
    public class XnesService:IXnesService
    {
        public XnesContext _context;
        public XnesService(XnesContext context)
        {
            _context = context;
        }

        public Customers GetCustomer(string tz)
        {
            Customers customer = null;
                try
            {
                customer =_context.Customers.Where(x=>x.Tz.Equals(tz)).First();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            return customer;
        }

        public void AddCustomer(Customers customer)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                _context.Add(new Customers
                {
                    FullName = customer.FullName,
                    Tz = customer.Tz,
                    FullNameEnglish = customer.FullNameEnglish,
                    BirthDate =customer.BirthDate,
                    City =customer.City,
                    Bank = customer.Bank,
                    BankBranch =customer.BankBranch,
                    AccountNumber =customer.AccountNumber
                });
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
        }
        public List<Customers> GetAllCustomers()
        {
            List<Customers> listCustomers=_context.Customers.ToList();
            return listCustomers;
        }

        public List<Cities> GetAllCities()
        {
            List<Cities> listCities = _context.Cities.ToList();
            return listCities;
        }
    }
}
