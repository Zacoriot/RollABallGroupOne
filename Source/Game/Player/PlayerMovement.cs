using FlaxEngine;

namespace Game;

/// <summary>
/// PlayerMovement Script.
/// </summary>
public class PlayerMovement : Script
{
    public override void OnUpdate()
    {
        Debug.Log(InputManager.GetMovementAxis());
    }
}
