using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Dot.Net.WebApi.Controllers.Domain
{
    public class Rating
    {
        // TODO: Map columns in data table RATING with corresponding fields
        [Key]
        public int RatingId { get; set; }

        public string MoodysRating { get; set; }
        public string SandRating { get; set; }
        public string FitchRating { get; set; }
        public int OrderNumber { get; set; }



    }
}