using Unity.Entities;

public struct CubeSpawnerData : IComponentData
{
    public Entity Prefab;
    public int numToSpawn;
}
