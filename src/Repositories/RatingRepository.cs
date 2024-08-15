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

        //returns first found rating matching id
        public Rating FindByRatingId(int ratingid)
        {
            return DbContext.Ratings.FirstOrDefault(Rating => Rating.Id == ratingid);
        }

        //returns array of all Ratings
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
