using UnityEngine;

public class GemSpawnerNormalVersion : MonoBehaviour
{
    [SerializeField] Gem[] gemPrefabs;
    [SerializeField] int spawnAmount = 50;
    [SerializeField] float spawnInterval = 0.5f;

    float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            var randomIndex = Random.Range(0, gemPrefabs.Length);
            var prefab = gemPrefabs[randomIndex];
            //传入Transforms使得宝石成为子对象
            var gem = Instantiate(prefab, transform);
            //随机位置半径
            gem.transform.position = transform.position + Random.insideUnitSphere * 2f;
            //随机旋转
            gem.transform.rotation = Random.rotation;
            //随机大小
            gem.transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f);
            //设置宝石的DeactivateAction
            gem.SetDeactivateAction(delegate { Destroy(gem.gameObject); });
        }
    }
}