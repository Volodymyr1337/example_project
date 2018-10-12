using Entitas;
using UnityEngine;

public class HelloWorldSystem : IInitializeSystem
{
    public void Initialize()
    {
        Debug.Log("HelloWorldSystem");
    }
}
