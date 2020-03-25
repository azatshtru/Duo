using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    bool isRunning;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void MovePlayer(float x)
    {
        if(x < -0.0f || x > 0.0f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        anim.SetBool("IsRunning", isRunning);

        if (x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void JumpPlayer()
    {
        anim.SetTrigger("IsJumping");
    }
}
