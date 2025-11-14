using Unity.Entities;

public struct BodySpawnerData : IComponentData
{
    public Entity Prefab;
    public int NumToSpawn;
}
