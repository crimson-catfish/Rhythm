using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;

    [Tooltip("if child of a spawn group time sets automaticly")]
    [SerializeField] private float spawnTimeInSeconds;

    private Transform spawnContainer;


    private void Start()
    {
        SpawnGroup spawnGroup = GetComponentInParent<SpawnGroup>();
        if (spawnGroup != null) spawnTimeInSeconds = spawnGroup.spawnTimeInSeconds;


        spawnContainer = GameObject.FindWithTag("SpawnContainer").transform;
        StartCoroutine("SpawnDelay");
    }


    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnTimeInSeconds);

        Vector3 spawnPosition = new Vector3(this.transform.position.x, enemyToSpawn.transform.position.y, this.transform.position.z);
        Instantiate(enemyToSpawn, spawnPosition, this.transform.rotation, spawnContainer);

        if (this.transform.parent.name == "EnemySpawnRoot") Destroy(this.gameObject);
        else Destroy(this.transform.parent.gameObject);
    }
}
