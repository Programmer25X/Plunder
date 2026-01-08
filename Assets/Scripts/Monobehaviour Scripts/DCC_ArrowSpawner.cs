using UnityEngine;

public class DCC_ArrowSpawner : MonoBehaviour
{
    public ArrowData arrowData;

    [Header("Spawner Properties")]
    [SerializeField] private GameObject spawner;

    private bool _isEnabled = true;
    private float _timeTillNextSpawn = 0;

    // Update is called once per frame
    void Update()
    {
        if (_isEnabled && Time.time > _timeTillNextSpawn)
        {
            Instantiate(arrowData.GetArrow(), spawner.transform.position, spawner.transform.rotation);
            _timeTillNextSpawn = Time.time + arrowData.GetCooldown();
        }
    }
}
