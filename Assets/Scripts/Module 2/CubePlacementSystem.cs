using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

partial struct CubePlacementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (cube,local,Entity) in SystemAPI.Query<RefRO<CubeData>, RefRW<LocalTransform>>().WithEntityAccess())
        {
            local.ValueRW.Position = cube.ValueRO.Position;
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
