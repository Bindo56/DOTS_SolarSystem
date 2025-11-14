using Unity.Entities;
using UnityEngine;

// NOTE! The CubeSpawnerAuthoring class derives from Monobaviour.
class CubeSpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public int numToSpawn;
}

// NOTE! The CubeSpawnerAuthoringBaker class DOES NOT derive from Monobehavior,
// but from Baker instead where the authoring type is the above CubeSpawnerAuthoring class.
class CubeSpawnerAuthoringBaker : Baker<CubeSpawnerAuthoring>
{
    public override void Bake(CubeSpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new CubeSpawnerData{
            Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
            numToSpawn = authoring.numToSpawn
        });
    }
}
