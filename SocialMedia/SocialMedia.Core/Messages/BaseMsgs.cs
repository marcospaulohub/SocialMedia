using System.Globalization;
using System.Resources;

namespace SocialMedia.Core.Messages
{
    public static class BaseMsgs
    {
        public static string GetResource(string key, string fileNameResx)
        {
            var rm = new ResourceManager(fileNameResx, typeof(BaseMsgs).Assembly);

            var text = rm.GetString(key, CultureInfo.CurrentCulture);

            if (text != null)
                return text;
            else
                return "null";
        }
    }
}
