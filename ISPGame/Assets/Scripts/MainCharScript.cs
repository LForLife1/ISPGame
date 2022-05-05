using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharScript : MonoBehaviour
{

	public float speedDefault = 3.5f;
	float speed;
	Rigidbody2D rigidbody2d;
	float horizontal;
	float vertical;

	public ParticleSystem unusedEffect;

	Animator animator;
	Vector2 lookDirection = new Vector2(1, 0);

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
		{

			speed = speedDefault;
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");

			Vector2 move = new Vector2(horizontal, vertical);



			if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
			{
				lookDirection.Set(move.x, move.y);
				lookDirection.Normalize();
			}

            animator.SetFloat("MoveX", lookDirection.x);
            animator.SetFloat("MoveY", lookDirection.y);
            //animator.SetFloat("Speed", move.magnitude);

        }
        else
        {
			speed = 0.0f;
		}

		//if (Input.GetKeyDown(KeyCode.X))
		//{
		//	RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
		//	if (hit.collider != null)
		//	{
		//		NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
		//		if (character != null)
		//		{
		//			character.DisplayDialog();
		//		}
		//	}
		//}
	}

	void FixedUpdate()
	{
		Vector2 position = rigidbody2d.position;
		position.x = position.x + speed * horizontal * Time.deltaTime;
		position.y = position.y + speed * vertical * Time.deltaTime;

		rigidbody2d.MovePosition(position);
	}
}