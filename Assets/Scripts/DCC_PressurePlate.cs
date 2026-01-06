using System.Collections;
using UnityEngine;

public class DCC_PressurePlate : MonoBehaviour
{
    [Header("Spawners")]
    [SerializeField] GameObject[] spawners;

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

    private void OnTriggerExit(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitAndDisable(3.0f));
        }
    }

    private IEnumerator WaitAndDisable(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (GameObject spawner in spawners)
        {
            if (spawner.activeSelf)
            {
                spawner.SetActive(false);
            }
        }
    }
}
