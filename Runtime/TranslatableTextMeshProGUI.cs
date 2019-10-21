using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ArsenStudio.I18n
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TranslatableTextMeshProGUI : TranslatableComponent
    {
        private TextMeshProUGUI TextComp;

        void Start()
        {
            TextComp = GetComponent<TextMeshProUGUI>();
            TextComp.text = LanguageManager.Tr(Key);
        }
    }
}
