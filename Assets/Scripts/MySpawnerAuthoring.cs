using Unity.Entities;
using UnityEngine;

class MySpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public int numToSpawn;
}

class MySpawnerAuthoringBaker : Baker<MySpawnerAuthoring>
{
    public override void Bake(MySpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MySpawnerData{
            Prefab = GetEntity(authoring.prefab),
            NumToSpawn = authoring.numToSpawn
        });
    }
}
