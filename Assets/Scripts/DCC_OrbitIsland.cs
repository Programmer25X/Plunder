using UnityEngine;

public class DCC_OrbitIsland : MonoBehaviour
{
    GameObject island;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        island = GameObject.Find("IslandTerrain");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(island.transform.position, Vector3.up, 10 * Time.deltaTime);
    }
}
