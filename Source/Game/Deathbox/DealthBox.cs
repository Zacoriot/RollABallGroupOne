using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game;

/// <summary>
/// DealthBox Script.
/// </summary>
public class DealthBox : Script
{
    [Serialize, ShowInEditor] SceneReference _Scene;

    public override void OnEnable()
    {
        Actor.As<Collider>().TriggerEnter += OnTriggerEnter;
    }

    public override void OnDisable()
    {
        Actor.As<Collider>().TriggerEnter -= OnTriggerEnter;
    }

    void OnTriggerEnter(PhysicsColliderActor collider)
    {
        if (collider.Parent.HasTag("Player"))
        {
            Level.ChangeSceneAsync(_Scene);
        }
    }

}
