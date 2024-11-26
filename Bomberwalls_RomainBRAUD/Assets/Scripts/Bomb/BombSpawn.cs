using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public static BombSpawn Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerSpawnBomb(Transform position)
    {
        GameObject bomb = PoolObjectBomb.instance.GetPooledObject();
        bomb.transform.position = position.position;
        bomb.SetActive(true);
        PlayerItems.Instance.PlayerGotABomb = false;
    }

    public void AISpawnBomb(Transform position)
    {
        GameObject bomb = PoolObjectBomb.instance.GetPooledObject();
        bomb.transform.position = position.position;
        bomb.SetActive(true);
        PlayerItems.Instance.AIGotABomb = false;
    }
}
