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


            if (context.CurvePoints.Any())
            {
                return;
            }

            context.CurvePoints.AddRange(
                new CurvePoint
                {
                    CurveId = 3456
                });


            context.SaveChanges();
        }
    }
}
