using System.Configuration;

namespace Aluminum.Web.Extensions
{
    public class ConfigurationExtensions
    {
        private const string CostumeImagesPathKey = "CostumeImagesPath";

        public static string GetCostumeImagesPath()
        {
            string costumeImagesPath = ConfigurationManager.AppSettings[CostumeImagesPathKey];

            return costumeImagesPath;
        }
    }
}