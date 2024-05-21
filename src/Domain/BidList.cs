using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Domain
{
    public class BidList
    {
        [Key]
        public int BidListId { get; set; }

        public string Account { get; set; }
        public string Type { get; set; }
        public double BidQuantity { get; set; }
        public double AskQuantity { get; set;}
        public double Bid { get; set; }
        public double Ask { get; set; }
        public string Benchmark { get; set; }
        public TimestampAttribute  BidListDate { get; set; }
        public string Commentary { get; set; }
        public string Security { get; set; }
        public string Status { get; set; }
        public string Trader { get; set; }
        public string Book { get; set; }
        public string CreationName { get; set; }
        public TimestampAttribute CreationDate { get; set; }
        public string RevisionName { get; set; }
        public TimestampAttribute RevisionDate { get; set; }
        public string DealName { get; set; }
        public string DealType { get; set; }
        public string SouceListId { get; set; }
        public string Side { get; set; }
    }
}