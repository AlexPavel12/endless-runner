using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject terrain;
    [SerializeField] private Transform terrainHolder;

    private Vector3 spawnPosition = new Vector3(0, 0, 15);

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(terrain, spawnPosition, Quaternion.identity, terrainHolder);
            spawnPosition += new Vector3(0, 0, 15);
        }
    }
}
