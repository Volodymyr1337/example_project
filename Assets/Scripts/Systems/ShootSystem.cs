using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ShootSystem : IExecuteSystem
{
    private Contexts _contexts;

    public ShootSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetButtonDown("Fire"))
        {
            var entity = _contexts.game.CreateEntity();
            var setup = _contexts.game.gameSetup.value;
            entity.AddResource(setup.Laser);
            var playerTransform = _contexts.game.playerEntity.view.Value.transform;
            var playerForward = playerTransform.up;
            entity.isLaser = true;
            entity.AddAcceleration(playerForward * setup.LaserSpeed);
            entity.AddInitialPsition(playerTransform.position);
        }
    }
}
