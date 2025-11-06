using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] tetrominoPrefabs;
    [SerializeField] private Transform spawnPoint;

    private GameObject currentPiece;
    private bool canSpawn = true;

    private void Start()
    {
        SpawnNextTetromino();
    }

    public void SpawnNextTetromino()
    {
        if (!canSpawn) return;

        int randomIndex = Random.Range(0, tetrominoPrefabs.Length);
        currentPiece = Instantiate(tetrominoPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
