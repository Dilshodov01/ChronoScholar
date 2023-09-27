using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Service.Dto.TextbookDto
{
    public class TextbookForCreationDto
    {
        public long UserId { get; set; }
        public long SellerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }
    }
}
