using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObjectModel.Domain
{  
    public enum GeoObjectStatus
    {
        Cancelled,
        In_process_of_generation,
        Current,
        Archived
    }
    public class GeographicalObject
    {
        
        public Guid Id { get; set; }
        public int GeoNameId { get; set; }
        public int ParentGeoNameId { get; set; }

        public GeoObjectStatus Status { get; set; }
      
        public DateTime UpdatedTime { get; set; }
        public DateTime CreationTime { get; set; }

        
        public string AreaTypeAsString 
        { 
            get
            {
                return "";
            }
              
        }// метод возвращает название типа района... сделал как свойство с методами по умолчанию get/set
        
        public string ChildGeographicalObjectNames { get
            {
                return "";
            } 
        }// метод возвращает описание списка внутренних районов... сделал как свойство с методами по умолчанию get/set
        public string ParentAreaName
        {
            get
            {
                return "";
            }
        }// метод возвращает текстовое поле родительского района... сделал как свойство с методами по умолчанию get/set
        public string StatusAsString { get
            {
                return "";
            }
                }// метод возвращает название статуса географического описания... сделал как свойство с методами по умолчанию get/set

        public Guid GeoNamesFeauteId { get; set; }
        public GeoNamesFeature GeoNamesFeature { get; set; } = null!;
        public List<GeometryVersion> GeometryVersions { get; set; } = null!;
        public GeographicalObjectVersion Detail { set; get; } = null!;
        public GeometryVersion Geometry { get; set; } = null!;
        public List<GeographicalObjectVersion> GeographicalObjectVersions { get; set; } = new List<GeographicalObjectVersion>();
        public List<ParentChildObjectLink> ParentGeographicalObjects { get; set; } = new List<ParentChildObjectLink>();
        public List<ParentChildObjectLink> ChildGeographicalObjects { get; set; } = new List<ParentChildObjectLink>();
        public List<NeighboringObjectLink> NeighboringGeographicalObjectsOut { get; set; } = new List<NeighboringObjectLink>();
        public List<NeighboringObjectLink> NeighboringGeographicalObjectsIn { get; set; } = new List<NeighboringObjectLink>();
      

    }
}
