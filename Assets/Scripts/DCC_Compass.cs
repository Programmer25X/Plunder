using UnityEngine;
using UnityEngine.UI;

public class DCC_Compass : MonoBehaviour
{
    [Header("Compass GUI Element")]
    [SerializeField][Tooltip("Sprite for the GUI Compass")] private Image compassImage; 
    private GameObject playerCharacter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!playerCharacter)
        {
            playerCharacter = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!compassImage)
        {
            Debug.LogError("Compass not set.");
            return;
        }
        else
        {
            compassImage.rectTransform.eulerAngles = new Vector3(0, 0, playerCharacter.transform.eulerAngles.y);
        }
    }
}
