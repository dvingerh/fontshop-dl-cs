namespace fontshop_dl_cs.Classes
{
    public static class Constants
    {
        public const string BASE_URL = "https://www.fontshop.com/search_data.json?search_mode=families&q={0}&size=1&fields=typeface_data,opentype_features";
        public const string BASE_CSS = "https://www.fontshop.com/webfonts/{0}.css";
        public const string CDN_REGEX = "(fast[^']*)";
    }
}
