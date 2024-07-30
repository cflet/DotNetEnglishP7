using System;
using System.Collections.Generic;
using System.Linq;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        public LocalDbContext DbContext { get; }

        public RatingRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Rating FindByRatingId(int ratingid)
        {
            return DbContext.Ratings.FirstOrDefault(Rating => Rating.RatingId == ratingid);
        }

        public Rating[] FindAll()
        {
            return DbContext.Ratings.ToArray();
        }

        public void Add(Rating rating)
        {
            DbContext.Add(rating);
            DbContext.SaveChanges();
        }

        public void Update(Rating rating)
        {
            DbContext.Update(rating);
            DbContext.SaveChanges();
        }

        public void Delete(Rating rating)
        {
            DbContext.Remove(rating);
            DbContext.SaveChanges();
        }
    }
}
