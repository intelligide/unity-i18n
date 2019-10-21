using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArsenStudio.I18n

{
    [RequireComponent(typeof(TextMesh))]
    public class TranslatableTextMesh : TranslatableComponent
    {
        private TextMesh TextComp;

        void Start()
        {
            TextComp = GetComponent<TextMesh>();
            TextComp.text = LanguageManager.Tr(Key);
        }
    }
}
