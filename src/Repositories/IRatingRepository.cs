using Dot.Net.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public interface IRatingRepository
    {
        Rating FindByRatingId(int ratingid);
        Rating[] FindAll();
        void Add(Rating rating);
        void Update(Rating rating);
        void Delete(Rating rating);

    }
}
