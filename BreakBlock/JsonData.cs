using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace BreakBlock {
    [DataContract]
    public class JsonData {
        [DataMember]
        public int BallNum { get; set; }
        [DataMember]
        public int BlockRowNum { get; set; }
        [DataMember]
        public int BlockColumnNum { get; set; }
        [DataMember]
        public int BarWidth { get; set; }
        [DataMember]
        public int BarHeight { get; set; }
    }
}
