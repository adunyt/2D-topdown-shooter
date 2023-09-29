using UnityEditor;
using UnityEngine;

namespace com.goldsprite.GSTools.EssentialAttributes
{
    [CustomPropertyDrawer(typeof(HideAttribute))]
    public class MyHideDrawer : PropertyDrawer
    {

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //不运行无高度
            return ((HideAttribute)attribute).GetIsAble() ? 0 : EditorGUI.GetPropertyHeight(property);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //不运行不绘制
            if (!((HideAttribute)attribute).GetIsAble())
                EditorGUI.PropertyField(position, property);
        }


    }


}