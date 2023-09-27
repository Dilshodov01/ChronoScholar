using ChronoScholar.Domain.Cammons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Domain.Entities
{
    public class Seller:Auditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
    }
}
