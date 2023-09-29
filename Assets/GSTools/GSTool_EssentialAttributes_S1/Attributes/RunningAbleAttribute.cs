using System;
using UnityEngine;


namespace com.goldsprite.GSTools.EssentialAttributes
{
    public class RunningAbleAttribute : PropertyAttribute
    {
        public enum OptType { All, InEditor, AtPlaying };
        public OptType Type;


        public RunningAbleAttribute() { }
        public RunningAbleAttribute(int type)
        {
            if (!Enum.IsDefined(typeof(OptType), type))
            {
                Debug.LogWarning($"[Error]: Invalid ReadOnly parameter of type {type} , Its Auto be set to \"All\". ");
                return;
            }
            this.Type = (OptType)type;
        }
        public RunningAbleAttribute(OptType type)
        {
            this.Type = type;
        }


        public bool GetIsAble()
        {
            return (Type == OptType.AtPlaying && Application.isPlaying) || (Type == OptType.InEditor && !Application.isPlaying) || Type == OptType.All;
        }


    }


}