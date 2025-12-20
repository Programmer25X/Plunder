using UnityEngine;

public class DCC_ArrowSpawner : MonoBehaviour
{
    private bool isEnabled = true;
    private float timeTillNextSpawn = 0;

    [SerializeField] private float coolDown = 0.5f;
    [SerializeField] private GameObject spawner; 
    [SerializeField] private GameObject arrow;

    // Update is called once per frame
    void Update()
    {
        if (isEnabled && Time.time > timeTillNextSpawn)
        {
            Instantiate(arrow, spawner.transform.position, spawner.transform.rotation);
            timeTillNextSpawn = Time.time + coolDown;
        }
    }
}
