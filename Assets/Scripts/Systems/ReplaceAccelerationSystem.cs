using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ReplaceAccelerationSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public ReplaceAccelerationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var input = _contexts.game.input.Value.y;
        var player = _contexts.game.playerEntity;
        var playerTransform = player.view.Value.transform;
        var forward = playerTransform.up;
        var acceleration = player.acceleration.Value;
        var movementSpeed = _contexts.game.gameSetup.value.PlayerMovementSpeed;
        player.ReplaceAcceleration(acceleration + input * forward * movementSpeed * Time.deltaTime);
    }
}
