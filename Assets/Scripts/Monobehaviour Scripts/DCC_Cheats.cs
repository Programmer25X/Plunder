using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class DCC_Cheats : MonoBehaviour
{
    [Header("Cheat Teleport Locations")]
    [SerializeField] private Transform _enterBlueChamberPosition;
    [SerializeField] private Transform _enterYellowChamberPosition;
    [SerializeField] private Transform _enterRedChamberPosition;
    [SerializeField] private Transform _caveEntrance;

    private CharacterController _characterController;

    private DCC_Prompt_Message _exitPromptMessageScript;

    private void Awake()
    {
        _exitPromptMessageScript = GameObject.Find("Exit").GetComponent<DCC_Prompt_Message>();
    }
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _characterController.enabled = false;
            transform.position = _enterBlueChamberPosition.position;
            _exitPromptMessageScript.ActivatePanel(false);
            _characterController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _characterController.enabled = false;
            transform.position = _enterRedChamberPosition.position;
            _exitPromptMessageScript.ActivatePanel(false);
            _characterController.enabled = true;

        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            _characterController.enabled = false;
            transform.position = _enterYellowChamberPosition.position;
            _exitPromptMessageScript.ActivatePanel(false);
            _characterController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _characterController.enabled = false;
            transform.position = _caveEntrance.transform.position;
            _characterController.enabled = true;
        }
    }

}
