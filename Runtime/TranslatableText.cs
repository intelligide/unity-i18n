using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace ArsenStudio.I18n
{
    [RequireComponent(typeof(Text))]
    public class TranslatableText : TranslatableComponent
    {
        private Text TextComp;

        void Start()
        {
            TextComp = GetComponent<Text>();
            TextComp.text = LanguageManager.Tr(Key);
        }
    }
}
