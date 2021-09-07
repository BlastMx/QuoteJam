using UnityEngine;

public class SpawningAliment : MonoBehaviour
{
    [SerializeField] private GameObject[] alimentPrefab;
    [SerializeField] private Transform arrow;


    private void Update()
    {
        Spawning();
    }

    private void Spawning()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject aliment = Instantiate(alimentPrefab[Random.Range(0, 3)]);

            aliment.transform.position = arrow.position;
            aliment.SetActive(true);
        }
    }
}
