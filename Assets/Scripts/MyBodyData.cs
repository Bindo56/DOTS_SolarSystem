using Unity.Entities;
using Unity.Mathematics;

public struct MyBodyData : IComponentData
{
    public float Mass;
    public float3 Velocity;
}
