namespace Web.Model.VO
{
    public class MetaVO
    {
        public MetaVO()
        {
        }

        public MetaVO(string title, string icon)
        {
            this.title = title;
            this.icon = icon;
        }

        public MetaVO(string title, string icon, bool noCache)
        {
            this.title = title;
            this.icon = icon;
            this.noCache = noCache;
        }

        public string title { get; set; }
        public string icon { get; set; }
        public bool noCache { get; set; }
    }
}