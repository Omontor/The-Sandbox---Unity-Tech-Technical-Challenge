using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;


[UpdateInGroup(typeof(LateSimulationSystemGroup))]
public class PlayerDestructionSystem : SystemBase
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
        .WithAll<DestroyTag, PlayerTag>()
        .ForEach((Entity entity, int nativeThreadIndex) =>
        {
            commandBuffer.DestroyEntity(nativeThreadIndex, entity);

        }).WithBurst().ScheduleParallel();

       
        m_EndSimEcb.AddJobHandleForProducer(Dependency);

    }
}
