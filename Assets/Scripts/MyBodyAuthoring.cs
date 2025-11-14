using Unity.Entities;
using UnityEngine;

class MyBodyAuthoring : MonoBehaviour
{
    public float mass;
}

class MyBodyAuthoringBaker : Baker<MyBodyAuthoring>
{
    public override void Bake(MyBodyAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MyBodyData
        {
            Mass = authoring.mass
        });
    }
}
