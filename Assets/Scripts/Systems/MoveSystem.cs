using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;



public class MoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Acceleration, GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var entity in _group.GetEntities())
        {
            GameObject view = entity.view.Value;
            Vector3 acceleration = entity.acceleration.Value;
            var position = view.transform.position;
            position += acceleration * Time.deltaTime;
            view.transform.position = position;
        }
    }
}
