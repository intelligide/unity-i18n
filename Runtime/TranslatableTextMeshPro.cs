using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ArsenStudio.I18n
{
    [RequireComponent(typeof(TextMeshPro))]
    public class TranslatableTextMeshPro : TranslatableComponent
    {
        private TextMeshPro TextComp;

        void Start()
        {
            TextComp = GetComponent<TextMeshPro>();
            TextComp.text = LanguageManager.Tr(Key);
        }
    }
}
