using Dot.Net.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public interface ITradeRepository
    {
        Trade FindByTradeId(int tradeId);
        Trade[] FindAll();
        void Add(Trade trade);
        void Update(Trade trade);
        void Delete(Trade trade);
    }
}