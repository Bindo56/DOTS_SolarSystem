using Unity.Entities;

public struct MySpawnerData : IComponentData
{
    public Entity Prefab;
    public int NumToSpawn;
}
