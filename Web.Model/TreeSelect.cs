using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Web.Model.Database;

namespace Web.Model
{
    [Serializable]
    public class TreeSelect
    {
        public TreeSelect()
        {
        }

        public TreeSelect(SysMenu sysMenu)
        {
            Id = sysMenu.MenuId;
            Label = sysMenu.MenuName;
        }

        public long? Id { get; set; }
        public string Label { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<TreeSelect> Children { get; set; }
    }
}