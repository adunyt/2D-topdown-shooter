using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameCloser : MonoBehaviour
{
    public void Close()
    {
        Application.Quit();
    }
}
