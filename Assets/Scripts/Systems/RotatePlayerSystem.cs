using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class RotatePlayerSystem : IExecuteSystem
{
    private Contexts _contexts;

    public RotatePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var input = _contexts.game.input.Value.x;
        var playerTransform = _contexts.game.playerEntity.view.Value.transform;
        var playerRotation = playerTransform.rotation.eulerAngles;
        playerRotation.z -= input * _contexts.game.gameSetup.value.RotationSpeed * Time.deltaTime;
        playerTransform.rotation = Quaternion.Euler(playerRotation);
    }
}
