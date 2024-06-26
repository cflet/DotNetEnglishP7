using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;

namespace WebApi.Repositories
{
    public interface ICurvePointRepository
    {
        CurvePoint FindByCurvePointId(int curvepointid);
        CurvePoint[] FindAll();
        void Add(CurvePoint curvepoint);
        void Update(CurvePoint curvepoint);
        void Delete(CurvePoint curvepoint);
    }
}
