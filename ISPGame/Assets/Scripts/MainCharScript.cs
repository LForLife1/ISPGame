using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharScript : MonoBehaviour
{
    /*Movement speeds*/
    public int walkSpeed = 10;
    public int runSpeed = 20;

    Animator animator;
    Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);

    bool canMove;
    public bool isMoving;

    public VectorValue startingPositionMainRoom;

    AudioSource audioSource;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        transform.position = startingPositionMainRoom.initialValue;
        this.transform.GetChild(0).gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        canMove = true;
    }

    public void Update()
    {

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }


        /*RightMovement*/
        if (canMove)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {       /*Checks if shift is pressed at the same time then it moves * runSpeed instead of walkSpeed. If not it will move by walkspeed*/
                animator.SetBool("Moving", true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
                }

            }

            /*Leftmovement*/
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetBool("Moving", true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
                }
            }

            /*UpMovement*/
            if (Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetBool("Moving", true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.up * runSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.up * walkSpeed * Time.deltaTime);
                }

            }

            /*DownMovement*/
            if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("Moving", true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.down * runSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.down * walkSpeed * Time.deltaTime);
                }

            }
            if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetBool("Moving", false);
            }
        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void changeMoveStatus()
    {
        canMove = !canMove;
    }
}