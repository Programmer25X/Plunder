using UnityEngine;

public class DCC_OrbitIsland : MonoBehaviour
{
  [SerializeField] private GameObject _island;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_island.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
