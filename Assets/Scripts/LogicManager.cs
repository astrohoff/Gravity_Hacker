using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage logic of gameobjects.
public class LogicManager : MonoBehaviour {
    private bool state;
    // Things that control this object's state.
    public LogicManager[] logicSources;
    // Things that this object's state controls.
    public LogicManager[] logicDesinations;
    // Negate the state of the corresponding source logic state.
    public bool[] negateLogicSources;

    // Check the logic sources to see if this objects state has changed.
    public void CheckLogicSources()
    {
        bool newState = true;
        // Look all the logic sources, stop if any are false.
        for (int i = 0; i < logicSources.Length && newState; i++)
        {
            bool sourceState = logicSources[i].state;
            // Negate if needed.
            if (i < negateLogicSources.Length && negateLogicSources[i])
            {
                sourceState = !sourceState;
            }
            // Combine this source state with previous source states.
            newState = newState && sourceState;
        }
        // Set this object's logic state as the new state.
        SetState(newState);
    }

    // Have all logic desinations recheck their sources.
    public void UpdateLogicDesinations()
    {
        for(int i = 0; i < logicDesinations.Length; i++)
        {
            logicDesinations[i].CheckLogicSources();
        }
    }

    // Update this object's logic state.
    public void SetState(bool newState)
    {
        // Only do anything if the state is different than the old state.
        if(newState != state)
        {
            state = newState;
            UpdateLogicDesinations();
            // Have any components for this object that use the logic state update accordingly.
            SendMessage("UpdateLogicState", SendMessageOptions.DontRequireReceiver);
        }
    }

    public bool GetState() { return state; }
}
