using System.Configuration;

namespace ZaolisShop.Helper
{
    public static class Constants
    {
        public static string ImageProductPath
        {
            get { return ConfigurationManager.AppSettings["ImageProductPath"]; }
        }
    }
}