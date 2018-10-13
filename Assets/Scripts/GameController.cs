using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    public GameSetup GameSetup;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGameSetup(GameSetup);

        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new HelloWorldSystem())

            .Add(new InputSystem(contexts))

            .Add(new InitializePlayerSystem(contexts))
            .Add(new InstantiateViewSystem(contexts))

            .Add(new RotatePlayerSystem(contexts))
            .Add(new ReplaceAccelerationSystem(contexts))

            .Add(new MoveSystem(contexts));
    }
}
