using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions
{
    public static Action OnEnterObstacle;
    public static Action OnHit;


    public static Action OnEnablePlayerMovement;
    public static Action<string, bool> SetUI;
    public static Action OnEnableObstacleSpawner;
    public static Action<string> OnClick;
}
