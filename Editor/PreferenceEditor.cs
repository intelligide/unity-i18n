using UnityEngine;
using UnityEditor;

namespace ArsenStudio.I18n
{
    [InitializeOnLoad]
    internal class EditorStartup {
        static EditorStartup()
        {
            var currentLang = EditorPrefs.GetString("Translations.current");
            LanguageManager.Load(currentLang);
        }
    }

    internal static class PreferenceEditor
    {
        private static bool prefsLoaded = false;

        private static string currentLang;

        public static int index = 0;

        [PreferenceItem("Translations")]
        private static void preferencesGUI()
        {
            if (!prefsLoaded)
            {
                currentLang = EditorPrefs.GetString("Translations.current");
                prefsLoaded = true;
            }
    
            var options = ListAvailableLanguages();
            index = EditorGUILayout.Popup("Editor language", index, options);
    
            if (GUI.changed)
            {
                currentLang = options[index];
                LanguageManager.Load(currentLang);
                EditorPrefs.SetString("Translations.current", currentLang);
            }
        }

        public static string[] ListAvailableLanguages()
        {
            var resources = Resources.LoadAll("I18n", typeof(TextAsset));

            var result = new string[resources.Length];

            for(int i = 0; i < resources.Length; i++)
            {
                result[i] = resources[i].name;
            }

            return result;
        }
    }
}
