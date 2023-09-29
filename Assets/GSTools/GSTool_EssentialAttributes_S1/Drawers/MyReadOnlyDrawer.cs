using UnityEditor;
using UnityEngine;

namespace com.goldsprite.GSTools.EssentialAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class MyReadOnlyDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //��ɫ���,�����޸�
            EditorGUI.BeginDisabledGroup(((ReadOnlyAttribute)attribute).GetIsAble());
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();

            //��һ��д��
            //GUI.enabled = !((ReadOnlyAttribute)attribute).GetIsAble();
            //EditorGUI.PropertyField(position, property);
            //GUI.enabled = !GUI.enabled;
        }


    }


}