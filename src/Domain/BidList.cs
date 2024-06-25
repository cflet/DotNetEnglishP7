using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Dot.Net.WebApi.Domain
{
    public class BidList
    {
        [Key]
        public int BidListId { get; set; }

        [Required]
        public string Account { get; set; }
        [Required]
        public string Type { get; set; }
       
        public double BidQuantity { get; set; }
        public double AskQuantity { get; set;}
        public double Bid { get; set; }
        public double Ask { get; set; }
        public string Benchmark { get; set; }
        public DateTime  BidListDate { get { return DateTime.Now; } }
        public string Commentary { get; set; }
        public string Security { get; set; }
        public string Status { get; set; }
        public string Trader { get; set; }
        public string Book { get; set; }
        public string CreationName { get; set; }
        public DateTime CreationDate { get { return DateTime.Now; } }
        public string RevisionName { get; set; }
        public DateTime RevisionDate { get; set; }
        public string DealName { get; set; }
        public string DealType { get; set; }
        public string SouceListId { get; set; }
        public string Side { get; set; }
    }
}