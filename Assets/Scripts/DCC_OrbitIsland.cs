using UnityEngine;

public class DCC_OrbitIsland : MonoBehaviour
{
  [SerializeField] private GameObject _objectToOrbit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_objectToOrbit.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
