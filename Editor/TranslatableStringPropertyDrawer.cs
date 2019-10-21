using UnityEditor;
using UnityEngine;

namespace ArsenStudio.I18n
{
    [CustomPropertyDrawer(typeof(TranslatableString))]
    public class TranslatableStringPropertyDrawer : PropertyDrawer
    {
        /*
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Create property container element.
            var container = new VisualElement();

            // Create property fields.
            var amountField = new PropertyField(property.FindPropertyRelative("amount"));
            var unitField = new PropertyField(property.FindPropertyRelative("unit"));
            var nameField = new PropertyField(property.FindPropertyRelative("name"), "Fancy Name");

            // Add fields to the container.
            container.Add(amountField);
            container.Add(unitField);
            container.Add(nameField);

            return container;
        }*/

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }

        private string keyVal, keyCache;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var keyProperty = property.FindPropertyRelative("Key");

            {
                var rect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
                property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, label);
            }

            {
                if (keyProperty.stringValue != keyVal)
                {
                    keyVal = keyProperty.stringValue;
                    keyCache = LanguageManager.Tr(keyProperty.stringValue);
                }

                var rect = new Rect(position.xMin + EditorGUIUtility.labelWidth, position.y, position.width, EditorGUIUtility.singleLineHeight);
                GUI.enabled = false;
                EditorGUI.TextField(rect, keyCache);
                GUI.enabled = true;
            }

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;

                {
                    var rect = new Rect(position.x, position.y + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
                    EditorGUI.PropertyField(rect, keyProperty);
                }

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }
    }
}
