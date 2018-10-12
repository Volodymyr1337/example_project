using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu, Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject Player;
}
