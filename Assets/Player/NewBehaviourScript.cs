using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

public class NewBehaviourScript : MonoBehaviour
{
    //[RuntimeInitializeOnLoadMethod]
    //private static void AppStart()
    //{
    //    var defaultSystems = PlayerLoop.GetDefaultPlayerLoop();
    //    var customUpdate = new PlayerLoopSystem()
    //    {
    //        updateDelegate = CustomUpdate,
    //        type = typeof(PlayerLoopTest)
    //    };
    //    ReplaceSystem<Update.ScriptRunBehaviourUpdate>(ref defaultSystems, customUpdate);
    //    PlayerLoop.SetPlayerLoop(defaultSystems);
    //}

    //private static void CustomUpdate()
    //{
    //    Debug.Log("Custom update running!");
    //}

    //private static bool ReplaceSystem<T>(ref PlayerLoopSystem system, PlayerLoopSystem replacement)
    //{
    //    if (system.type == typeof(T))
    //    {
    //        system = replacement;
    //        return true;
    //    }
    //    if (system.subSystemList != null)
    //    {
    //        for (var i = 0; i < system.subSystemList.Length; i++)
    //        {
    //            if (ReplaceSystem(system.subSystemList[i], replacement, toReplace))
    //            {
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}
}
