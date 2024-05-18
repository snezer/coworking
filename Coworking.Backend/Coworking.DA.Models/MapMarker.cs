using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.DA.Models
{
    public class MapMarker
    {
        public MapMarker() { }

        public long Id { get; set; }
        public string? PointX { get; set; }
        public string? PointY { get; set; }
        public string? Title { get; set; }
        public long RoomId {  get; set; }
        public long LandlordId { get; set; }
    }
}
