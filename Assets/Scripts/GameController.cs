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
    
    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new HelloWorldSystem())
            .Add(new InitializePlayerSystem(contexts));
    }
}
