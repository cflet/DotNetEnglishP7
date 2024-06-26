using System;
using System.Collections.Generic;
using System.Linq;
using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class CurvePointRepository : ICurvePointRepository
    {
        public LocalDbContext DbContext { get; }

        public CurvePointRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public CurvePoint FindByCurvePointId(int curvepointid)
        {
            return DbContext.CurvePoints.FirstOrDefault(CurvePoint => CurvePoint.Id == curvepointid);
        }

        public CurvePoint[] FindAll()
        {
            return DbContext.CurvePoints.ToArray();
        }

        public void Add(CurvePoint curvepoint)
        {
            DbContext.Add(curvepoint);
            DbContext.SaveChanges();
        }

        public void Update(CurvePoint curvepoint)
        {
            DbContext.Update(curvepoint);
            DbContext.SaveChanges();
        }

        public void Delete(CurvePoint curvepoint)
        {
            DbContext.Remove(curvepoint);
            DbContext.SaveChanges();
        }

    }
}
