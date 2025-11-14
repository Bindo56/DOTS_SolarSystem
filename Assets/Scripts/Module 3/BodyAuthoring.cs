using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class BodyAuthoring : MonoBehaviour
{
    public float Mass;
}

class BodyAuthoringBaker : Baker<BodyAuthoring>
{
    public override void Bake(BodyAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new BodyData{
            Mass = authoring.Mass
        });
    }
}
