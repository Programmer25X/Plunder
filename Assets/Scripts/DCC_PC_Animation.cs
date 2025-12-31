using UnityEngine;

public class DCC_PC_Animation : MonoBehaviour
{
    private Animator _pcAnimator; 
    private CharacterController _characterController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _pcAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            _pcAnimator.SetBool("bl_run", true);
        }
        else
        {
            _pcAnimator.SetBool("bl_run", false);
        }

        if (Input.GetAxis("Vertical") > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            _pcAnimator.SetBool("bl_walkForwards", true);
        }
        else
        {
            _pcAnimator.SetBool("bl_walkForwards", false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            _pcAnimator.SetBool("bl_walkBackwards", true);
        }
        else
        {
            _pcAnimator.SetBool("bl_walkBackwards", false);
        }
        
        if(Input.GetAxis("Vertical") == 0)
        {
            _pcAnimator.SetBool("bl_walkForwards", false);
            _pcAnimator.SetBool("bl_walkBackwards", false);
            _pcAnimator.SetBool("bl_run", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _pcAnimator.SetBool("bl_jump", true); 
        }
        else
        {
            _pcAnimator.SetBool("bl_jump", false);
        }
    }
}
