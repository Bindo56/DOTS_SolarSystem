using Unity.Entities;

public struct MyBodySpawnerData : IComponentData
{
    public Entity Prefab;
    public int NumToSpawn;
}
