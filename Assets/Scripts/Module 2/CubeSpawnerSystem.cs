using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

partial struct CubeSpawnerSystem : ISystem
{

    Unity.Mathematics.Random rng;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        rng = new Unity.Mathematics.Random(123);
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        foreach(var (spawner, entity) in SystemAPI.Query<RefRO<CubeSpawnerData>>().WithEntityAccess()){
            ProcessSpawner(ref state, spawner, ecb);
            ecb.DestroyEntity(entity);
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    private void ProcessSpawner(ref SystemState state, RefRO<CubeSpawnerData> spawner, EntityCommandBuffer ecb){
        for(int i = 0; i < spawner.ValueRO.numToSpawn; i++){

            Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);

            ecb.AddComponent<CubeData>(newEntity);
            ecb.SetComponent(newEntity, new CubeData{
                Position = new float3(GetRandomFloat(), GetRandomFloat(), GetRandomFloat()),
            });
        }
    }

    private float GetRandomFloat(){
        return rng.NextFloat(-100f, 100f);
    }

}
