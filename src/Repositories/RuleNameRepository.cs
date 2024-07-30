using System;
using System.Collections.Generic;
using System.Linq;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class RuleNameRepository : IRuleNameRepository
    {
        public LocalDbContext DbContext { get; }

        public RuleNameRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public RuleName FindByRuleNameId(int ruleNameId)
        {
            return DbContext.RuleNames.FirstOrDefault(RuleName => RuleName.Id == ruleNameId);
        }

        public RuleName[] FindAll()
        {
            return DbContext.RuleNames.ToArray();
        }

        public void Add(RuleName ruleName)
        {
            DbContext.Add(ruleName);
            DbContext.SaveChanges();
        }

        public void Update(RuleName ruleName)
        {
            DbContext.Update(ruleName);
            DbContext.SaveChanges();
        }

        public void Delete(RuleName ruleName)
        {
            DbContext.Remove(ruleName);
            DbContext.SaveChanges();
        }
    }
}
