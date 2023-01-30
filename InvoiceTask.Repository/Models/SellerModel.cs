using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Repository.Models
{
    public class SellerModel 
    {
        public string Region { get; set; }
        public bool IsVat { get; set; } = true;
    }
}
