using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObjectModel.Domain;
using GeoObjectModel.Infrostraction;
using Microsoft.EntityFrameworkCore;


namespace TestProject1
{
    public class TestHelper
    {
        private readonly Context _context; 

        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase(databaseName: "GeoObjectDb");

            var dbContextOptions = builder.Options;
            _context = new Context(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            
        }

        public GeographicalObjectRepository GeographicalObjectRepository
        {
            get
            {
                return new GeographicalObjectRepository(_context);
            }
        }
    }
}
