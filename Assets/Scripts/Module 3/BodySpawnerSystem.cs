using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;

partial struct BodySpawnerSystem : ISystem
{
    uint counter;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<BodySpawnerData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var bodiesQuery = SystemAPI.QueryBuilder().WithAll<BodyData>().Build();

        if(bodiesQuery.IsEmpty)
        {
            var prefab = SystemAPI.GetSingleton<BodySpawnerData>().Prefab;
            var instances = state.EntityManager.Instantiate(prefab, SystemAPI.GetSingleton<BodySpawnerData>().NumToSpawn, Allocator.Temp);
            var random = Random.CreateFromIndex(counter++);

            foreach(var entity in instances)
            {
                var transforms = SystemAPI.GetComponentRW<LocalTransform>(entity);
                transforms.ValueRW.Position = (new float3(random.NextFloat(), 0, random.NextFloat()) - new float3(0.5f, 0, 0.5f)) * 100;
            }

            foreach(var entity in SystemAPI.Query<RefRW<BodyData>>()){
                entity.ValueRW.Velocity = random.NextFloat3() - new float3(0.5f, 0.5f, 0.5f) * 10;
            }
        }

        
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

}
