using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu, Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject Player;
    public GameObject Laser;

    public float LaserSpeed = 10f;
    public float RotationSpeed = 180f;
    public float PlayerMovementSpeed = 5f;
    public float AsteroidSpeed = 0.3f;

    public GameObject[] Bigs;
    public GameObject[] Meds;
    public GameObject[] Smalls;
    public GameObject[] Tinys;

}
