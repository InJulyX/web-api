using System.Collections.Generic;

namespace Web.Model.VO
{
    public class RouterVO
    {
        public string name { get; set; }
        public string path { get; set; }
        public bool hidden { get; set; }
        public string redirect { get; set; }
        public string component { get; set; }
        public bool alwaysShow { get; set; }
        public MetaVO meta { get; set; }
        public IEnumerable<RouterVO> children { get; set; }
        public string ZhName { get; set; }
        public long? MenuId { get; set; }
    }
}