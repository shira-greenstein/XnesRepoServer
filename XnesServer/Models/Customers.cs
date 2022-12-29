using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XnesServer.Models
{
    public class Customers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Tz { get; set; }
        public string FullName { get; set; }
        public string FullNameEnglish { get; set; }
        public DateTime BirthDate { get; set; }
        public int City { get; set; }
        public int Bank { get; set; }
        public int BankBranch { get; set; }
        public string AccountNumber { get; set; }
        public virtual Cities Cities { get; set; }
    }
}
