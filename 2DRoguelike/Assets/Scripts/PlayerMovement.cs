using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
		if(direction.x != 0 || direction.y !=0)
		{
        	SetAnimatorMovement(direction);
		} else {
			anim.SetLayerWeight(1,0);
		}

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;            
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;            
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;            
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;            
        }
    }
    
    private void SetAnimatorMovement(Vector2 direction)
    {
		anim.SetLayerWeight(1,1);
        anim.SetFloat("xDir",direction.x);
        anim.SetFloat("yDir",direction.y);
    }
}
