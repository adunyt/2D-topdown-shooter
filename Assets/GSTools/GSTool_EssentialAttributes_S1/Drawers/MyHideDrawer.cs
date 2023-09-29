using UnityEditor;
using UnityEngine;

namespace com.goldsprite.GSTools.EssentialAttributes
{
    [CustomPropertyDrawer(typeof(HideAttribute))]
    public class MyHideDrawer : PropertyDrawer
    {

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //�������޸߶�
            return ((HideAttribute)attribute).GetIsAble() ? 0 : EditorGUI.GetPropertyHeight(property);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //�����в�����
            if (!((HideAttribute)attribute).GetIsAble())
                EditorGUI.PropertyField(position, property);
        }


    }


}