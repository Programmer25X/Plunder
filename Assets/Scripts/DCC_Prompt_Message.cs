
using UnityEngine;
using TMPro;

public class DCC_Prompt_Message : MonoBehaviour
{
    [Header("GUI Properties")]
    [SerializeField][Tooltip("Prompt message displayed on the GUI")] private string message;
    [SerializeField][Tooltip("Interaction distance")] private float interactDistance = 2.0f;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI textWindow;

    private GameObject pc;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = GameObject.FindWithTag("Player");
        messagePanel = GameObject.Find("Message_Panel");
        textWindow = messagePanel.GetComponent<TextMeshProUGUI>();
        messagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(pc.transform.position, transform.position) < interactDistance)
        {
                messagePanel.SetActive(true);
                textWindow.text = message;

        }
        else if (Vector3.Distance(pc.transform.position, transform.position) < interactDistance + 1)
        {
                messagePanel.SetActive(false);
        }
    }
}
