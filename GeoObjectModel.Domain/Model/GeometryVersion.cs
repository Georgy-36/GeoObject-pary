using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObjectModel.Domain
{
    public class GeometryVersion
    {

        public Guid Id { get; set; }
        public int Version { get; set; }
        public GeoObjectStatus Status { get; set; }
        public DateTime ArchiveTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreationTime { get; set; }
        public string UpperLeftCornerGeocode { get; set; }
        public string LowerRightCornerGeocode { get; set; }
        public string BorderGeocodes{ get; set; } 
        public double AreaVolue { get; set; }
        public double WestToEastLength { get; set; }
        public double NorthToSouthLength { get; set; }
        public Guid GeographicalObjectId { get; set; }
        public GeographicalObject GetGeographicalObject { get; set; } = null!;

    }
}
