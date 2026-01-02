
using TMPro;
using UnityEngine;

public class DCC_Prompt_Message : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField][TextArea] private string _messageToDisplay = "Replace with appropriate message";
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private TextMeshProUGUI _textWindow;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_messagePanel.activeSelf)
        {
            _messagePanel.SetActive(false);
        }
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            _messagePanel.SetActive(true);
            _textWindow.text = _messageToDisplay;
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            _messagePanel.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (_messagePanel != null)
        {
            _messagePanel.SetActive(false);
        }
    }
}
