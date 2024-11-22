using FlaxEngine;

namespace Game;

/// <summary>
/// PlayerMovement Script.
/// </summary>
public class PlayerMovement : Script
{
    RigidBody _Rigibody;

    [Header("==MOVEMENT==")]
    [ShowInEditor, Serialize] float _RollSpeed;

    public override void OnStart()
    {
        _Rigibody = (RigidBody)Actor;
    }

    public override void OnFixedUpdate()
    {
        Vector3 finalForce = new Vector3(InputManager.GetMovementAxis().X,
                                        0,
                                        InputManager.GetMovementAxis().Y);

        finalForce = finalForce.Normalized * _RollSpeed;

        _Rigibody.AddForce(finalForce);
    }
}
