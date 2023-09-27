using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Exceptions
{
    public class ChronoScholarExceptions:Exception
    {
        public long StatusCode { get; set; }
        public ChronoScholarExceptions(int code, string message) : base(message)
        {
            StatusCode = code;
        }
    }
}
