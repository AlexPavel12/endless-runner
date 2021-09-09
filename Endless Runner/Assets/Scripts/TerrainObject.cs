using UnityEngine;

public class TerrainObject : MonoBehaviour
{
    [SerializeField] private Transform[] sides;
    [SerializeField] private GameObject obstacle;

    private void Start()
    {
        if (Random.value > .5f)
        {
            int sideIndex = Random.Range(0, sides.Length);
            Instantiate(obstacle, sides[sideIndex].position + obstacle.transform.position, Quaternion.identity);
        }
    }
}
