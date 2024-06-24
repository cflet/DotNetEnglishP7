using System;
using System.Collections.Generic;
using System.Linq;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class BidListRepository : IBidListRepository
    {
        public LocalDbContext DbContext { get; }

        public BidListRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BidList FindByBidListId(int bidlistid)
        {
            return DbContext.BidLists.FirstOrDefault(BidList => BidList.BidListId == bidlistid);
        }

        public BidList[] FindAll()
        {
            return DbContext.BidLists.ToArray();
        }

        public void Add(BidList bidlist)
        {
            DbContext.Add(bidlist);
            DbContext.SaveChanges();
        }

        public void Update(BidList bidlist)
        {
            DbContext.Update(bidlist);
            DbContext.SaveChanges();
        }

        public void Delete(BidList bidlist)
        {
            DbContext.Remove(bidlist);
            DbContext.SaveChanges();
        }
    }
}

