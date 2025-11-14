using Unity.Entities;
using UnityEngine;

class MyBodySpawnerAuthoring : MonoBehaviour
{
    public int numToSpawn;
    public GameObject prefab;
}

class MyBodySpawnerAuthoringBaker : Baker<MyBodySpawnerAuthoring>
{
    public override void Bake(MyBodySpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new MyBodySpawnerData
        {
            NumToSpawn = authoring.numToSpawn,
            Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic)
        });
    }
}
