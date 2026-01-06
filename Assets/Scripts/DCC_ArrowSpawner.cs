using UnityEngine;

public class DCC_ArrowSpawner : MonoBehaviour
{
    [Header("Arrow Properties")]
    [SerializeField] private float coolDown = 0.5f;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject arrow;

    private bool _isEnabled = true;
    private float _timeTillNextSpawn = 0;

    // Update is called once per frame
    void Update()
    {
        if (_isEnabled && Time.time > _timeTillNextSpawn)
        {
            Instantiate(arrow, spawner.transform.position, spawner.transform.rotation);
            _timeTillNextSpawn = Time.time + coolDown;
        }
    }
}
