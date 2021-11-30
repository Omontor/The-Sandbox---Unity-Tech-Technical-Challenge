using Unity.Entities;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Burst;

public class InputSpawnSystem : SystemBase
{

    private EntityQuery m_PlayerQuery;
    private BeginSimulationEntityCommandBufferSystem m_BeginSimECB;
    private Entity m_Prefab;

    protected override void OnCreate()
    {

        m_PlayerQuery = GetEntityQuery(ComponentType.ReadWrite<PlayerTag>());
        m_BeginSimECB = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {

        if (m_Prefab == Entity.Null)
        {
            m_Prefab = GetSingleton<PlayerAuthoringComponent>().Prefab;
            return;
        }
        byte shoot;
        shoot = 0;
        var playerCount = m_PlayerQuery.CalculateEntityCountWithoutFiltering();

        if (Input.GetKey("space"))
        {
            shoot = 1;
        }

        if (shoot == 1 && playerCount < 1)
        {
            EntityManager.Instantiate(m_Prefab);
            return;
        }
    }
}