using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 targetPos;
    public float speed;
    private Vector2 direction;
    private Animator anim;
    public float dashRange;
    private enum Facing {UP,DOWN,LEFT,RIGHT};
    private Facing FacingDir = Facing.DOWN;

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
            FacingDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;  
            FacingDir = Facing.LEFT;           
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;  
            FacingDir = Facing.DOWN;           
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;  
            FacingDir = Facing.RIGHT;           
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 currentPos = transform.position;
            targetPos = Vector2.zero;
            if (FacingDir == Facing.UP)
            {
                targetPos.y = 1;
            }
            else if (FacingDir == Facing.DOWN)
            {
                targetPos.y = -1;
            }
            else if (FacingDir == Facing.LEFT)
            {
                targetPos.x = -1;
            }
            else if (FacingDir == Facing.RIGHT)
            {
                targetPos.x = 1;
            }

            transform.Translate(targetPos*dashRange);
        }
    }
    
    private void SetAnimatorMovement(Vector2 direction)
    {
		anim.SetLayerWeight(1,1);
        anim.SetFloat("xDir",direction.x);
        anim.SetFloat("yDir",direction.y);
    }
}
