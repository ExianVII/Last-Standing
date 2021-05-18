//Basic movement controller
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;


public class Reijak : MonoBehaviour
{
 
    //Variables for the animations
    public PlayerController ReijakController;
    public float walkSpeed = 40f;
    float horizontalMov = 10f;

    public Animator anim;

    [SerializeField] private StatusManager PlayerStatus;
    bool jump = false;
    bool crouch = false;

    bool aa = false;
    int saCost = 50;
    bool sa = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMov = Input.GetAxisRaw("Horizontal") * walkSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMov));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
   
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            anim.SetBool("isCrouching", true);
        }

        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            anim.SetBool("isCrouching", false);
        }

        else if (Input.GetButtonDown("AutoAttack"))
        {
            aa = true;
            anim.SetBool("isAttack", true);

        }
        else if (Input.GetButtonUp("AutoAttack"))
        {
            aa = false;
            anim.SetBool("isAttack", false);
        }
        else if (Input.GetButtonDown("SpecialAttack"))
        {
            sa = true;
            anim.SetBool("isSpecialAttack", true);
            PlayerStatus.SkillUsed(saCost);
           

        }
        else if (Input.GetButtonUp("SpecialAttack") ||
            PlayerStatus.EnergyBar.value < 0)
        {
            sa = false;
            anim.SetBool("isSpecialAttack", false);
            PlayerStatus.NoEnergy();
        }

    }

    private void FixedUpdate()
    {

        ReijakController.Movement(horizontalMov *
            Time.deltaTime, crouch, jump, aa, sa);
        jump = false;
    }

   

}
