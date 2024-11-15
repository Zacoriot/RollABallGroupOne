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

    // INPUT ACTIONS

    public override void OnAwake()
    {
        _VerticalInputAxis = new InputAxis("Vertical");
        _HorizontalInputAxis = new InputAxis("Horizontal");
    }


    public override void OnDestroy()
    {
        _VerticalInputAxis.Dispose();
        _HorizontalInputAxis.Dispose();
    }

    public static Vector2 GetMovementAxis()
    {
        return new Vector2(_HorizontalInputAxis.ValueRaw, _VerticalInputAxis.ValueRaw);
    }
}
