using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace ArsenStudio.I18n
{
    public static class LanguageManager
    {
        private static Dictionary<string, string> translations = null;

        public static void Load(string localeCode)
        {
            translations = new Dictionary<string, string>();

            TextAsset txtAsset = Resources.Load<TextAsset>("I18n/" + localeCode);
            if(txtAsset == null)
            {
                Debug.LogError("Cannot find translation file for locale \"" + localeCode + "\"");
                return;
            }
            string xmlStr = txtAsset.text;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);

            foreach(XmlNode trNode in xmlDoc.DocumentElement.GetElementsByTagName("string"))
            {
                translations.Add(trNode.Attributes["key"].Value, trNode.InnerText);
            }

            // string absolute = Path.GetFullPath("Packages/com.arsenstudio.i18n/Resources/i18n.xsd");
        }

        public static string Tr(string key)
        {
            if(translations == null || !translations.ContainsKey(key))
            {
                Debug.LogWarning("Language Manager: Cannot find translation for \"" + key + "\"");
                return "[Missing translation]";
            }
            return translations[key];
        }
    }
}
