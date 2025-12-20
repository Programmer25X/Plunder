using UnityEngine;

public class DCC_PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        foreach(GameObject spawner in spawners)
        {
            if(spawner.activeSelf)
            {
                spawner.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if(triggerHit.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player activated trap");

            foreach (GameObject spawner in spawners)
            {
                if(!spawner.activeSelf)
                {
                    spawner.SetActive(true);
                }
            }
        }
    }
}
