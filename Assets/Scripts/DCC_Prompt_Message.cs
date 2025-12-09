
using UnityEngine;
using TMPro;

public class DCC_Prompt_Message : MonoBehaviour
{
    [Header("GUI Properties")]
    [SerializeField][Tooltip("Prompt message displayed on the GUI")] private string message;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI textWindow;

    [SerializeField] private bool isHittingInteractable = false;

    private GameObject pc;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = GameObject.FindWithTag("Player");
        messagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHittingInteractable)
        {
            messagePanel.SetActive(true);
            textWindow.text = message;

        }
        else if (!isHittingInteractable)
        {
            messagePanel.SetActive(false);
        }
    }

    public void IsHittingInteractable(bool isPCrNear)
    {
        isHittingInteractable = isPCrNear;
    }
}
