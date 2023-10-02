using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour
{
    public void Test(BaseEventData baseEventData)
    {
        print(baseEventData.selectedObject.name);
    }
}
