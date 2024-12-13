using FlaxEngine;

namespace Game;

/// <summary>
/// InputManager Script.
/// </summary>
public class InputManager : Script
{
    // INPUT AXIS
    static InputAxis _VerticalInputAxis;
    static InputAxis _HorizontalInputAxis;

    // INPUT EVENT
    static InputEvent _JumpEvent;

    public override void OnAwake()
    {
        _VerticalInputAxis = new InputAxis("Vertical");
        _HorizontalInputAxis = new InputAxis("Horizontal");

        _JumpEvent = new InputEvent("Jump");
    }


    public override void OnDestroy()
    {
        _VerticalInputAxis.Dispose();
        _HorizontalInputAxis.Dispose();

        _JumpEvent.Dispose();
    }

    public static Vector2 GetMovementAxis()
    {
        return new Vector2(_HorizontalInputAxis.ValueRaw, _VerticalInputAxis.ValueRaw);
    }

    public static InputEvent GetJumpEvent() => _JumpEvent;
}
