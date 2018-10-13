using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _contexts.game.ReplaceInput(new Vector3(horizontal, vertical, 0f));
    }
}
