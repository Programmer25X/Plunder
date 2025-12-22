using System.Net.Sockets;
using UnityEngine;

public class DCC_SecretEntrancePedestals : MonoBehaviour
{
    [SerializeField] private string _pedestalName;

    private DCC_OpenEntrance openEntrance;

    private void Start()
    {
        openEntrance = GameObject.Find("Secret Entrance").GetComponent<DCC_OpenEntrance>();
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (_pedestalName == "Red" && triggerHit.gameObject.CompareTag("Gem_3"))
        {
            openEntrance.SetIsRedGemPlaced(true);
        }

        if (_pedestalName == "Yellow" && triggerHit.gameObject.CompareTag("Gem_2"))
        {
            openEntrance.SetIsYellowGemPlaced(true); 
        }

        if (_pedestalName == "Blue" && triggerHit.gameObject.CompareTag("Gem_1"))
        {
            openEntrance.SetIsBlueGemPlaced(true);
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (_pedestalName == "Red" && triggerHit.gameObject.CompareTag("Gem_3"))
        {
            openEntrance.SetIsRedGemPlaced(false);
        }

        if (_pedestalName == "Yellow" && triggerHit.gameObject.CompareTag("Gem_2"))
        {
            openEntrance.SetIsYellowGemPlaced(false);
        }

        if (_pedestalName == "Blue" && triggerHit.gameObject.CompareTag("Gem_1"))
        {
            openEntrance.SetIsBlueGemPlaced(false);
        }
    }
}
