using UnityEngine;

public class Bubble_Spawner : Base_Factory
{

    [SerializeField] private GameObject _bubble;
    [SerializeField] private Transform _spawnPoint;
    public override Bubble SpawnBubble()
    {
        GameObject enemyGO = Instantiate(_bubble, _spawnPoint.position, Quaternion.identity);
        return enemyGO.GetComponent<Bubble>();
    }
}
