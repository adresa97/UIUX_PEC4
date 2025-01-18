using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleBehaviour : BasicBehaviour
{
    public override void EnterInteraction()
    {
        base.EnterInteraction();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
