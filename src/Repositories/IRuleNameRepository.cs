using Dot.Net.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public interface IRuleNameRepository
    {
        RuleName FindByRuleNameId(int ruleNameId);
        RuleName[] FindAll();
        void Add(RuleName ruleName);
        void Update(RuleName ruleName);
        void Delete(RuleName ruleName);

    }
}
