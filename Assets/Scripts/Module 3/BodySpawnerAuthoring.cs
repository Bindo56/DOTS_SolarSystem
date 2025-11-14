using Unity.Entities;
using UnityEngine;

class BodySpawnerAuthoring : MonoBehaviour
{
    public int numToSpawn;
    public GameObject prefab;
}

class BodySpawnerAuthoringBaker : Baker<BodySpawnerAuthoring>
{
    public override void Bake(BodySpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new BodySpawnerData{
            NumToSpawn = authoring.numToSpawn,
            Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic)
        });
    }
}
