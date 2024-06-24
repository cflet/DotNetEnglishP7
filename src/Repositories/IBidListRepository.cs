using Dot.Net.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public interface IBidListRepository
    {
        BidList FindByBidListId(int bidlistid);
        BidList[] FindAll();
        void Add(BidList bidlist);
        void Update(BidList bidlist);
        void Delete(BidList bidlist);
    }
}
