using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            LocalDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<LocalDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (context.BidLists.Any())
            {
                return;
            }

            context.BidLists.AddRange(
                new BidList
                {
                    Account = "12345",
                    Type = "Not sure",
                    BidQuantity = 5.5,
                    AskQuantity = 4.6,
                    Bid = 1.2,
                    Ask = 3.4,
                    Benchmark = "What is this"
                }

                );
            context.SaveChanges();
        }
    }
}
