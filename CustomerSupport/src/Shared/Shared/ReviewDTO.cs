using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shared
{
    public class ReviewDTO
    {
        public int CustomerId { get; set; }
        public string? ReviewText { get; set; }
        public int Rating { get; set; }
    }
}

