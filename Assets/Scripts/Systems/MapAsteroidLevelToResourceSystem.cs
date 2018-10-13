using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAsteroidLevelToResourceSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public MapAsteroidLevelToResourceSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asteroid);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsteroid;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var setup = _contexts.game.gameSetup.value;
        foreach (var entity in entities)
        {
            entity.AddResource(MapAsteroidLevelToResource(entity.asteroid.Level, setup));
            var speed = _contexts.game.gameSetup.value.AsteroidSpeed;
            var randomAngle = Random.Range(0f, 2f);

            entity.AddAcceleration(new Vector3(speed * Mathf.Cos(randomAngle), speed * Mathf.Sin(randomAngle), 0f));
        }
    }

    private GameObject MapAsteroidLevelToResource(int level, GameSetup setup)
    {
        switch(level)
        {
            case 0:
                return setup.Tinys[Random.Range(0, setup.Tinys.Length)];
            case 1:
                return setup.Smalls[Random.Range(0, setup.Smalls.Length)];
            case 2:
                return setup.Meds[Random.Range(0, setup.Meds.Length)];
            case 3:
                return setup.Bigs[Random.Range(0, setup.Bigs.Length)];
            default:
                return setup.Tinys[Random.Range(0, setup.Tinys.Length)];
        }
    }
}
