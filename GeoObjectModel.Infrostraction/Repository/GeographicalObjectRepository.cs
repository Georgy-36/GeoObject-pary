using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoObjectModel.Domain;

namespace GeoObjectModel.Infrostraction
{
    public class GeographicalObjectRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public GeographicalObjectRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<GeographicalObject>> GetAllAsync()
        {
            return await _context.GeographicalObjects.DistinctBy(p => p.UpdatedTime).ToListAsync();
        }

        public async Task<GeographicalObject> GetByIdAsync(Guid id)
        {
           var geoObject = await _context.GeographicalObjects
                .Include(P => P.ParentGeographicalObjects)
                .Include(c => c.ChildGeographicalObjects)
                .Where(O => O.Id == id).FirstOrDefaultAsync();

             /*geoObject.Detail = await _context.GeographicalObjectVersions
                .Where(O => O.GetGeographicalObject.Id == id) 
                .OrderBy(v => v.Version).FirstOrDefaultAsync();*/

            return geoObject;     
        }



        public async Task AddAsync(GeographicalObject geographicalObject)
        {
            _context.GeographicalObjects.Add(geographicalObject);
            await _context.SaveChangesAsync();
        }

    }
}
