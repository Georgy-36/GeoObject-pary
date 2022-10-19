using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObjectModel.Domain
{
    

    public class NeighboringObjectLink
    {

        public Guid Id { get; set; }
        public string GeographicalObjectAName { get; set; }
        public string GeographicalObjectBName { get; set; } 
        public GeoObjectStatus Status { get; set; }
        public int A2BNumber { get; set; }
        public int B2ANumber { get; set; }
        public int A2BCornersOfTheEarth { get; set; }
        public int B2ACornersOfTheEarth { get; set; } 
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public Guid NeighboringGeographicalObjectsOutId { get; set; }
        public GeographicalObject NeighboringGeographicalObjectsOut { get; set; }
        public Guid NeighboringGeographicalObjectsInId { get; set; }
        public GeographicalObject NeighboringGeographicalObjectsIn { get; set; }
        public GeographicalObject NeighborningGeographicalObjectsLinkA { get; set; }
        public Guid NeighboringGeographicalObjectAId { get; set; }
        public GeographicalObject NeighborningGeographicalObjectsLinkB { get; set; }
        public Guid NeighboringGeographicalObjectBId { get; set; }


    }
}
