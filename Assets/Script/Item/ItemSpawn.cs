using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goodPrefab;
    [SerializeField] private GameObject badPrefab;

    [SerializeField] private Transform topSpawner;
    [SerializeField] private Transform bottomSpawner;

    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float xMin = -3f;
    [SerializeField] private float xMax = 3f;

    private float timer;
    private IObjectResolver resolver;
    [Inject]
    public void Inject(IObjectResolver objectResolver){this.resolver = objectResolver;}

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            SpawnGood();
            SpawnBad();
        }
    }

    private void SpawnGood()
    {
        float randomX = Random.Range(xMin, xMax);
        Vector3 spawnPos = new Vector3(randomX, topSpawner.position.y, topSpawner.position.z);

        var injectSpawnItem = Instantiate(goodPrefab, spawnPos, Quaternion.identity);
        resolver.InjectGameObject(injectSpawnItem);
    }

    private void SpawnBad()
    {
        float randomX = Random.Range(xMin, xMax);
        Vector3 spawnPos = new Vector3(randomX, bottomSpawner.position.y, bottomSpawner.position.z);

        var injectSpawnItem = Instantiate(badPrefab, spawnPos, Quaternion.identity);
        resolver.InjectGameObject(injectSpawnItem);
    }
}