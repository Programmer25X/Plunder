using UnityEngine;

public class DCC_SecretEntrancePedestals : MonoBehaviour
{
    [Header("Pedestal Properties")]
    [SerializeField] private string _pedestalName;

    private DCC_OpenEntrance _openEntrance;

    private void Start()
    {
        _openEntrance = GameObject.Find("Secret Entrance").GetComponent<DCC_OpenEntrance>();
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (_pedestalName == "Red" && triggerHit.gameObject.CompareTag("Gem_3"))
        {
            _openEntrance.SetIsRedGemPlaced(true);
        }

        if (_pedestalName == "Yellow" && triggerHit.gameObject.CompareTag("Gem_2"))
        {
            _openEntrance.SetIsYellowGemPlaced(true);
        }

        if (_pedestalName == "Blue" && triggerHit.gameObject.CompareTag("Gem_1"))
        {
            _openEntrance.SetIsBlueGemPlaced(true);
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (_pedestalName == "Red" && triggerHit.gameObject.CompareTag("Gem_3"))
        {
            _openEntrance.SetIsRedGemPlaced(false);
        }

        if (_pedestalName == "Yellow" && triggerHit.gameObject.CompareTag("Gem_2"))
        {
            _openEntrance.SetIsYellowGemPlaced(false);
        }

        if (_pedestalName == "Blue" && triggerHit.gameObject.CompareTag("Gem_1"))
        {
            _openEntrance.SetIsBlueGemPlaced(false);
        }
    }
}
