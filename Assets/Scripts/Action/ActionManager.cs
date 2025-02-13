using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager instance;

    public Stack<Action> actions = new Stack<Action>();

    void Awake()
    {
        instance = this;
    }

    public void AddAction(Action action)
    {
        actions.Push (action);
    }

    public void Undo()
    {
        if (
            actions.Count > 0 &&
            !(
            actions.Peek().toBranch.isCheering ||
            actions.Peek().toBranch.isJumping
            )
        )
        {
            Action action = actions.Pop();
            action.Undo();
        }
    }

    public void ClearActions()
    {
        actions.Clear();
    }
}
