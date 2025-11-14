using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


partial struct MyGravitySystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        var job = new MyGravityJob
        {
            DeltaTime = SystemAPI.Time.DeltaTime,
            ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
        };
        job.Schedule();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    [BurstCompile]
    partial struct MyGravityJob : IJobEntity
    {
        public float DeltaTime;
        public EntityCommandBuffer ECB;
        public void Execute(Entity entity , ref MyBodyData bodyData , ref LocalTransform transform)
        {
            transform.Position += bodyData.Velocity * DeltaTime;

            var force = 6.674f + (bodyData.Mass * 1000f) / math.distancesq(transform.Position, new float3(0,0,0));
            var direction = new float3 (0,0,0) - transform.Position;

            if(math.distance(transform.Position,new float3(0,0,0)) > 5)
            {
                bodyData.Velocity += math.normalize(direction) * force * DeltaTime;
            }

            if(math.distance(transform.Position,new float3(0,0,0)) > 100f || math.distance(transform.Position , new float3(0,0,0))< 5f)
            {
                ECB.DestroyEntity(entity);
            }

        }
    }
}
