using System;
using UnityEngine;

namespace ArsenStudio.I18n
{
    [Serializable]
    public class TranslatableString
    {
        [SerializeField]
        private string Key;

        public override string ToString()
        {
            return LanguageManager.Tr(Key);
        }

        public static explicit operator string(TranslatableString b)
        {
            return b.ToString();
        }
    }
}
