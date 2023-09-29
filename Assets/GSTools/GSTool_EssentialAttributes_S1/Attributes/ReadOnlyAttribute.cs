using System;
using UnityEngine;


namespace com.goldsprite.GSTools.EssentialAttributes
{
    public class ReadOnlyAttribute : RunningAbleAttribute
    {
        public ReadOnlyAttribute() { }
        public ReadOnlyAttribute(int type) : base(type) { }
        public ReadOnlyAttribute(OptType type) : base(type) { }
    }


}