﻿
using Enums;
using Unity.Assertions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using static GameVariables;

public class WeaponInitializer
{
    public static void Initialize()
    {
        if(Player.PlayerWeaponEntities.Count > 0)
            Reset();
        
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        Assert.IsNotNull(entityManager);
        //Create weapons for player
        Entity pistol = entityManager.Instantiate(WeaponHolder.WeaponPrefabDict[WeaponType.Pistol]);
        entityManager.SetComponentData(pistol, new Parent
        {
            Value = Player.Entity
        });
        Player.PlayerWeaponEntities.Add(WeaponType.Pistol, pistol);
        
        Entity shotgun = entityManager.Instantiate(WeaponHolder.WeaponPrefabDict[WeaponType.Shotgun]);
        entityManager.SetComponentData(shotgun, new Parent
        {
            Value = Player.Entity
        });
        entityManager.SetEnabled(shotgun, false);
        Player.PlayerWeaponEntities.Add(WeaponType.Shotgun, shotgun);
        
        Entity machinegun = entityManager.Instantiate(WeaponHolder.WeaponPrefabDict[WeaponType.Machinegun]);
        entityManager.SetComponentData(machinegun, new Parent
        {
            Value = Player.Entity
        });
        entityManager.SetEnabled(machinegun, false);
        Player.PlayerWeaponEntities.Add(WeaponType.Machinegun, machinegun);
        
        Player.PlayerWeaponTypes.Add(WeaponType.Pistol);
        Player.PlayerWeaponTypes.Add(WeaponType.Shotgun);
        Player.PlayerWeaponTypes.Add(WeaponType.Machinegun);
        
        
        
    }

    public static void Reset()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        foreach (var playerWeaponEntity in Player.PlayerWeaponEntities)
        {
            entityManager.DestroyEntity(playerWeaponEntity.Value);
        }
        Player.PlayerWeaponEntities.Clear();
    }
}