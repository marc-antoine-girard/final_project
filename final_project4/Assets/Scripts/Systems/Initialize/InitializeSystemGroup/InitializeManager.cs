﻿using Unity.Entities;
using UnityEngine;

[DisableAutoCreation]
[AlwaysUpdateSystem]
public class InitializeManager : ComponentSystemGroup
{
    private InputSystem inputSystem;
    private SwapWeaponSystem swapWeaponSystem;
    private PlayerTargetSystem playerTargetSystem;
    private GameLogicSystem gameLogicSystem;

    protected override void OnCreate()
    {
        var world = World.DefaultGameObjectInjectionWorld;

        inputSystem = world.GetOrCreateSystem<InputSystem>();
        swapWeaponSystem = world.GetOrCreateSystem<SwapWeaponSystem>();
        playerTargetSystem = world.GetOrCreateSystem<PlayerTargetSystem>();
        //pathFinding= world.GetOrCreateSystem<PathFinding>();
        gameLogicSystem = world.GetOrCreateSystem<GameLogicSystem>();

        var initialize = world.GetOrCreateSystem<InitializeManager>();

        initialize.AddSystemToUpdateList(inputSystem);
        initialize.AddSystemToUpdateList(swapWeaponSystem);
        initialize.AddSystemToUpdateList(playerTargetSystem);
        initialize.AddSystemToUpdateList(gameLogicSystem);
    }

    protected override void OnUpdate()
    {
        gameLogicSystem.Update();
        //Debug.Log("Initialize Manager Update");
        if (GameVariables.InputEnabled)
        {
            //Dependency: None   
            inputSystem.Update();

            swapWeaponSystem.Update();

            //Dependency: InputSystem
            playerTargetSystem.Update();
        }

        //TODO REMOVE
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            //Debug.Log("Fade in...");
            GlobalEvents.CameraEvents.FadeIn();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            //Debug.Log("Fade out...");
            GlobalEvents.CameraEvents.FadeOut();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GlobalEvents.CameraEvents.ShakeCam(0.2f, 3, 3);
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
#if UNITY_EDITOR
            Debug.Log("Oh no! You killed yourself lol");
#endif
            LifeComponent life = EntityManager.GetComponentData<LifeComponent>(GameVariables.Player.Entity);
            life.Kill();
            EntityManager.SetComponentData(GameVariables.Player.Entity, life);
        }
    }

    protected override void OnDestroy()
    {
    }

    public void OnSwapLevel()
    {
    }
}