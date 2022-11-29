using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObjectModel.Domain
{
    public class NeighboringObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<NeighboringObjectLink> NeighboringObjectLinks { get; set; } = new List<NeighboringObjectLink>();
        public string AreaNeighboring
        {
            get
            {
                return "";
            }
        }
    }
}
