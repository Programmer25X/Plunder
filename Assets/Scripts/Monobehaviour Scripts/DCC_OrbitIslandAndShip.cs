using UnityEngine;

public class DCC_OrbitIslandAndShip : MonoBehaviour
{
    [Header("Orbiting Camera")]
    [SerializeField] private GameObject _objectToOrbit;

    void Update()
    {
        transform.RotateAround(_objectToOrbit.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
