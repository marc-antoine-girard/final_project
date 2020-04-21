﻿using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static GameVariables;

[DisableAutoCreation]
[UpdateAfter(typeof(StateMovingSystem))]
public class StateAttackingSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref StateData stateData, in InputComponent ic) =>
        {
            if (ic.Shoot)
            {
                stateData.Value = StateActions.ATTACKING;
            }
        }).Schedule();

        var playerpos = EntityManager.GetComponentData<Translation>(Player.Entity);
        //Act on all entities with AttackStateData and EnemyTag
        Entities.WithAll<EnemyTag>().ForEach((ref StateData state, in Translation currentPosition, in AttackStateData range) =>
        {
            //Compare distance between current position and target position. If distance <= range -> set state to attack
            if (math.distancesq(currentPosition.Value, playerpos.Value) <= range.Value * range.Value)
            {
                state.Value = StateActions.ATTACKING;
            }
        }).ScheduleParallel();
    }
}