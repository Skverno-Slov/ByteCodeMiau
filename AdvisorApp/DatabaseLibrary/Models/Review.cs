using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int EntertamentId { get; set; }
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Rating { get; set; }
    }
}
