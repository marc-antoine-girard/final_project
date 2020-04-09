﻿using System.Collections;
using System.Collections.Generic;
using Unity.Physics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Serialization;
[CreateAssetMenu(menuName = "Scriptables/Player")]
public class PlayerAssetsScriptableObject : ScriptableObject
{
    [Header("Transform")]
    public Translation position;
    public Rotation rotation;
    public Scale scale;
    public LocalToWorld localToWorld;
    
    [Header("Inputs")] 
    public InputComponent inputs;
    
    [Header("Animation")] 
    public RenderMesh renderMesh;
    public AnimationTestScriptableObject animationTestSequence;
    
    [Header("Physics")] 
    public Velocity velocity;
    public PhysicsCollider hitbox;
}
