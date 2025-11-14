using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

partial struct MySpawnerSystem : ISystem
{
    Random rng;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        rng = new Random(123);
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
        foreach(var(spawner , entity) in SystemAPI.Query<RefRO<MySpawnerData>>().WithEntityAccess())
        {
            ProcessSpawner(ref state , spawner , ecb);
            ecb.DestroyEntity(entity);
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    private void ProcessSpawner(ref SystemState state , RefRO<MySpawnerData> spawner , EntityCommandBuffer ecb)
    {
        for (int i = 0; i < spawner.ValueRO.NumToSpawn; i++)
        {
            Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
            ecb.AddComponent<MyCubeData>(newEntity);
            ecb.SetComponent(newEntity, new MyCubeData
            {
                Position = new float3(RNG(), RNG(), RNG())
            });
        }
    }

    private float RNG()
    {
        return rng.NextFloat(-100f,100f);
    } 
   
}
