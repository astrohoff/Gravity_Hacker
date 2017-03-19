using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour {
    private bool state;
    public LogicManager[] logicSources;
    public LogicManager[] logicDesinations;

    public void CheckLogicSources()
    {
        if (logicSources.Length > 0)
        {
            bool newState = true;
            for (int i = 0; i < logicSources.Length && newState; i++)
            {
                newState = newState && logicSources[i].state;
            }
            SetState(newState);
        }
    }

    public void UpdateLogicDesinations()
    {
        for(int i = 0; i < logicDesinations.Length; i++)
        {
            logicDesinations[i].CheckLogicSources();
        }
    }

    public void SetState(bool newState)
    {
        if(newState != state)
        {
            state = newState;
            UpdateLogicDesinations();
            SendMessage("UpdateLogicState", SendMessageOptions.DontRequireReceiver);
        }
    }


    public bool GetState() { return state; }
}
