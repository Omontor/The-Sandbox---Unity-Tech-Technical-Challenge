using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

//We are going to update LATE once all other systems are complete
//because we don't want to destroy the Entity before other systems have
//had a chance to interact with it if they need to
[UpdateInGroup(typeof(LateSimulationSystemGroup))]
public class AsteroidsDestructionSystem : SystemBase
{
    private EndSimulationEntityCommandBufferSystem m_EndSimEcb;

    protected override void OnCreate()
    {
 
        m_EndSimEcb = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
      
        var commandBuffer = m_EndSimEcb.CreateCommandBuffer().AsParallelWriter();

        Entities
        .WithAll<DestroyTag, AsteroidTag>()
        .ForEach((Entity entity, int nativeThreadIndex) =>
        {
            commandBuffer.DestroyEntity(nativeThreadIndex, entity);

        }).ScheduleParallel();

    
        m_EndSimEcb.AddJobHandleForProducer(Dependency);

    }
}