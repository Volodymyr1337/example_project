using Entitas;
using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySystem : ReactiveSystem<GameEntity> {

    private Contexts _contexts;

    public DestroySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }


    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasView)
            {
                var view = entity.view.Value;
                view.Unlink();
                Object.Destroy(view);
            }
            entity.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }
}
