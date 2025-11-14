using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


partial struct GravitySystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        var job = new GravityJob 
            {
                deltaTime = SystemAPI.Time.DeltaTime,
                ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            };
        job.Schedule();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    [BurstCompile]
    partial struct GravityJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer ECB;

        void Execute(Entity entity, ref BodyData body, ref LocalTransform transform)
        {
            transform.Position += body.Velocity * deltaTime;

            var force = 6.674f * (body.Mass * 1000f) / math.distancesq(transform.Position, new float3(0, 0, 0));
            var direction = new float3(0, 0, 0) - transform.Position;

            if(math.distance(transform.Position, new float3(0, 0, 0)) > 5){
                body.Velocity += math.normalize(direction) * force * deltaTime;
            }

            if(math.distance(transform.Position, new float3(0, 0, 0)) > 100f ||
               math.distance(transform.Position, new float3(0, 0, 0)) < 5){
                ECB.DestroyEntity(entity);
            }
        }
    }
}