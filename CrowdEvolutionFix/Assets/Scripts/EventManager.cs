using UnityEngine;
using System;
public static class EventManager 
{
    public static event Action<GameObject> manDown;
    public static void Event_ManDown(GameObject man) {manDown?.Invoke(man);}
}
