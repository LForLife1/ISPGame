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

    public Quest quest;
    public VectorValue startingPositionMainRoom;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        transform.position = startingPositionMainRoom.initialValue;
        this.transform.GetChild(0).gameObject.SetActive(false);
        //Time.timeScale = 0.5f;
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
        if (Input.GetKey(KeyCode.RightArrow))
        {       /*Checks if shift is pressed at the same time then it moves * runSpeed instead of walkSpeed. If not it will move by walkspeed*/
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.down * runSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * walkSpeed * Time.deltaTime);
            }

        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);


        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Character"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
                if (character.charName == "EvilMainMan" && !character.completedQuest)
                {
                    character.giveQuest1();
                }
            }
        }

    }

}