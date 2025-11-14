using Unity.Entities;
using Unity.Mathematics;

public struct BodyData : IComponentData
{
    public float Mass;
    public float3 Velocity;
}
