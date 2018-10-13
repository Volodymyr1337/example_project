using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaserSystem : ReactiveSystem<GameEntity>
{

    private Contexts _contexts;

    public RotateLaserSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Laser, GameMatcher.Acceleration));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isLaser && entity.hasView && entity.hasAcceleration;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var view = entity.view.Value.transform;
            var acceleration = entity.acceleration.Value;
            view.transform.up = acceleration.normalized;
        }
    }
}
