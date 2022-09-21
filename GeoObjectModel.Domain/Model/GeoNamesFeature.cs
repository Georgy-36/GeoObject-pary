using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObjectModel.Domain
{
    public class GeoNamesFeature
    {
        public Guid Id { get; set; }
        public string GeoNamesFeatureCode { get; set;}
        public string GeoNamesFeatureKind { get; set; }
        public string FeatureKindNameEn { get; set; }
        public string FeatureNameEn { get; set; }
        public string FeatureKindNameRu { get; set; }
        public string FeatureNameRu { get; set; }
        public string CommentsEn { get; set; }
        public string CommentsRu { get; set; }
        public List<GeographicalObject> GeographicalObjects { get; set; } = null!;

    }
}
