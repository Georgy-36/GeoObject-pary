using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObjectModel.Domain
{
    public class GeographicalObjectVersion
    {

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string AuthoritativeKnowledgeSource { get; set; }
        public int Version { get; set; }
        public string LanguageCode { get; set; }
        public string Language { get; set; }
        public GeoObjectStatus Status { get; set; }
        public DateTime ArchiveTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreationTime { get; set; }
        public string CommonInfo { get; set; } 
        public Guid GeographicalObjectId { get; set; }
        public GeographicalObject GetGeographicalObject { get; set; } = null!;

    }
}
