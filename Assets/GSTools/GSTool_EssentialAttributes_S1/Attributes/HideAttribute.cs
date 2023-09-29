using System;
using UnityEngine;

namespace com.goldsprite.GSTools.EssentialAttributes
{
    public class HideAttribute : RunningAbleAttribute
    {
        public HideAttribute() { }
        public HideAttribute(int type) : base(type) { }
        public HideAttribute(OptType type) : base(type) { }
    }


}