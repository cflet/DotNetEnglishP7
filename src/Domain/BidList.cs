using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Domain
{
    public class BidList
    {
        [Key]
        public int BidListId { get; set; }

        public string account { get; set; }
        public string type { get; set; }
        public double bidQuantity { get; set; }
        public double askQuantity { get; set;}
        public double bid { get; set; }
        public double ask { get; set; }
        public string benchmark { get; set; }
        public TimestampAttribute  bidListDate { get; set; }
        public string commentary { get; set; }
        public string security { get; set; }
        public string status { get; set; }
        public string trader { get; set; }
        public string book { get; set; }
        public string creationName { get; set; }
        public TimestampAttribute creationDate { get; set; }
        public string revisionName { get; set; }
        public TimestampAttribute revisionDate { get; set; }
        public string dealName { get; set; }
        public string dealType { get; set; }
        public string souceListId { get; set; }
        public string side { get; set; }
    }
}