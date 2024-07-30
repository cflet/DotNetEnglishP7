using System;
using System.Collections.Generic;
using System.Linq;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        public LocalDbContext DbContext { get; }

        public TradeRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Trade FindByTradeId(int tradeId)
        {
            return DbContext.Trades.FirstOrDefault(Trade => Trade.TradeId == tradeId);
        }

        public Trade[] FindAll()
        {
            return DbContext.Trades.ToArray();
        }

        public void Add(Trade trade)
        {
            DbContext.Add(trade);
            DbContext.SaveChanges();
        }

        public void Update(Trade trade)
        {
            DbContext.Update(trade);
            DbContext.SaveChanges();
        }

        public void Delete(Trade trade)
        {
            DbContext.Remove(trade);
            DbContext.SaveChanges();
        }
    }
}
