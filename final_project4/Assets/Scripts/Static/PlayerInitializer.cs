﻿using Enums;
using Unity.Assertions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using static GameVariables;

public static class PlayerInitializer
{
    public static void Initialize()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        
        if (Player.Entity != Entity.Null)
            entityManager.DestroyEntity(Player.Entity);
        
        Assert.IsNotNull(entityManager);

        //Create player entity
        Entity player = entityManager.Instantiate(PlayerHolder.PlayerPrefabDict[PlayerType.Player]);
        //Give player an animation batch
        entityManager.AddSharedComponentData(player, new AnimationBatch
        {
            BatchId = AnimationHolder.AddAnimatedObject()
        });
        entityManager.SetComponentData(player, new Translation
        {
            Value = new float3(3, 1, 20)
        });
        /*
        entityManager.SetComponentData(player, new Rotation
        {
            Value = quaternion.identity //TODO SET SPAWN ROTATION
        });*/
        Player.Entity = player;
        Player.CurrentWeaponHeld = WeaponType.Pistol;
    }
    public static void SetPosition()
    {
        
    }

    
    public static void SetDefault<T>(T Component)
    {
        
    }

    public static void ResetToDefault()
    {
    }
}