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

    [Header("==JUMP==")]
    [ShowInEditor, Serialize] float _JumpForce;

    [Header("==GROUND DETECTION==")]
    [ShowInEditor, Serialize] float _GroundDetectRadius;
    [ShowInEditor, Serialize] Vector3 _GroundDetectOffset;
    [ShowInEditor, Serialize] LayersMask _GroundMask;
    bool _IsGrounded => Physics.CheckSphere(Actor.Position + _GroundDetectOffset, _GroundDetectRadius, _GroundMask);

    public override void OnEnable()
    {
        InputManager.GetJumpEvent().Pressed += Jump;
    }

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

    void Jump()
    {
        if(!_IsGrounded)
        {
            return;
        }

        _Rigibody.AddForce(Vector3.Up * _JumpForce);
    }

    public override void OnDebugDraw()
    {
        DebugDraw.DrawWireSphere(
            new BoundingSphere(Actor.Position + _GroundDetectOffset, _GroundDetectRadius),
            Color.Green);
    }
}
