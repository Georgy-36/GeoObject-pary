using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObjectModel.Domain
{
    public class ParentChildObjectLink
    {
        public Guid Id { get; set; }
        public string ParentGeographicalObjectName { get; set; }
        public string ChildGeographicalObjectName { get; set; }
        public bool CompletelyIncludedFlag { get; set; }
        public double IncludedPercent { get; set; }
        public DateTime CreationDateTime { get; set;}
        public DateTime LastUpdatedDateTime { get; set; }
        public Guid GeographicalObjectParentId { get; set; } 
        public GeographicalObject GeographicalObjectParent { get; set; }
        public Guid GeographicalObjectChildId { get; set; }
        public GeographicalObject GeographicalObjectChild { get; set; }
    }
}
