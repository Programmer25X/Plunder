using UnityEngine;

public class DCC_PC_Animation : MonoBehaviour
{
    private Animator pcAnimator; 
    private CharacterController characterController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        pcAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            pcAnimator.SetBool("bl_run", true);
        }
        else
        {
            pcAnimator.SetBool("bl_run", false);
        }

        if (Input.GetAxis("Vertical") > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            pcAnimator.SetBool("bl_walkForwards", true);
        }
        else
        {
            pcAnimator.SetBool("bl_walkForwards", false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            pcAnimator.SetBool("bl_walkBackwards", true);
        }
        else
        {
            pcAnimator.SetBool("bl_walkBackwards", false);
        }


        /*
        if(Input.GetButtonDown("Jump"))
        {
            pcAnimator.SetBool("bl_jump", true);
        }
        else
        {
            pcAnimator.SetBool("bl_jump", false);
        }

        */
    }
}
