using UnityEditor;
using UnityEngine;

namespace com.goldsprite.GSTools.EssentialAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class MyReadOnlyDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //灰色面板,不可修改
            EditorGUI.BeginDisabledGroup(((ReadOnlyAttribute)attribute).GetIsAble());
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();

            //另一种写法
            //GUI.enabled = !((ReadOnlyAttribute)attribute).GetIsAble();
            //EditorGUI.PropertyField(position, property);
            //GUI.enabled = !GUI.enabled;
        }


    }


}