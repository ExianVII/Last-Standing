using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float JumpForce = 400f;
    [Range(0, 1)] [SerializeField] private  float CrouchSpeed = .36f;
    [Range(0, .3f)] [SerializeField] private float MovSmoothing = .05f;
    [SerializeField] private  bool AirMove = false;
    [SerializeField] private  LayerMask GroundLevel;
    [SerializeField] private  Transform GroundCheck;
    [SerializeField] private  Transform CelingCheck;
    [SerializeField] private Collider2D CrouchingCollider; // the collider will be disabled when crouching.

    const float onGroundLength = .7f;
    private static bool isOnGround;
    const float canStand = 0.3f;

    private  Rigidbody2D playerRBD;
    private  bool playerFacingRight = true; //checks for the direction the player is facing.
    
    private  Vector3 velocity = Vector3.zero;

    private bool MirrorHP = true; //checks the direction of the HP Slider
    private bool MirrorEn = true; //checks the direction of the Energy Slider
    private RectTransform playerHealth;
    private RectTransform playerEnergy;

    private void Awake()
    {
        playerRBD = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("HP").
            GetComponentInChildren<RectTransform>();

        playerEnergy = GameObject.FindGameObjectWithTag("Energy").
            GetComponentInChildren<RectTransform>();
    }


    // Checks if the player is on anything that can be considered the ground
    private void FixedUpdate()
    {
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll
            (GroundCheck.position, onGroundLength, GroundLevel);

        for (int i = 0; i < colliders.Length; i++)
        {
            isOnGround = true;
        }
    }

    public void Movement(float move, bool crouch, bool jump, bool sa, bool aa)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(CelingCheck.position, canStand, GroundLevel))
            {
                crouch = true;
            }
        }

        if (isOnGround || AirMove)
        {
            if (crouch)
            {
                move *= CrouchSpeed;

                if (CrouchingCollider != null)
                {
                    CrouchingCollider.enabled = false;
                }
            }

            else
            {
                if (CrouchingCollider != null)
                {
                    CrouchingCollider.enabled = true;
                    sa = false;
                    aa = false;
                }
            }
            


            Vector3 targetVelocity =
                new Vector2(move * 10f, playerRBD.velocity.y);

            playerRBD.velocity =
                Vector3.SmoothDamp
                (playerRBD.velocity, targetVelocity, ref velocity, move);

            if (move > 0 && !playerFacingRight)
            {
                Flip();
        
            }

            else if (move < 0 && playerFacingRight)
            {
                Flip();
         
            }

            if(move < 0 && playerFacingRight)
            {
                Flip();
          
            }

        }

        if(isOnGround && jump)
        {
            isOnGround = false;
            playerRBD.AddForce(new Vector2(0f, JumpForce));
        }
    }
  
   
    private void Flip()
    {
      playerFacingRight = !playerFacingRight;

        Vector3 scale = playerRBD.transform.localScale;
        scale.x *= -1;
        playerRBD.transform.localScale = scale;

        HPFlip();
        EnergyFlip();
    }
    void HPFlip()
   {
        MirrorHP = !MirrorHP;
        Vector3 theScale = playerHealth.localScale;
       theScale.x *= -1;

         playerHealth.localScale = theScale;
     }

    void EnergyFlip()
    {
        MirrorEn = !MirrorEn;
        Vector3 theScale = playerEnergy.localScale;
        theScale.x *= -1;

        playerEnergy.localScale = theScale;
    }


}
