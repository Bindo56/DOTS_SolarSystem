using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

partial struct MyMovementScript : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach(var(cube,local,Entity) in SystemAPI.Query<RefRO<MyCubeData>, RefRW<LocalTransform>>().WithEntityAccess())
        {
            local.ValueRW.Position = cube.ValueRO.Position;
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
