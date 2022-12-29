using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XnesServer.Models;

namespace XnesServer.Services
{
    public class XnesService
    {
        public XnesContext _context;
        public XnesService(XnesContext context)
        {
            _context = context;
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


    }
}
