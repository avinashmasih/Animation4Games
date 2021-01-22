using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMotion : MonoBehaviour
{
    public Animator anim;
    public float speed = 1.5f;
    public float rotSpeed = 100.0f;

    private float Rot;
    private float Trans;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rot = Input.GetAxis("Horizontal") * rotSpeed;
        Trans = Input.GetAxis("Vertical");

        //anim.SetFloat("Rot", Rot);
        //anim.SetFloat("Trans", Trans);

        Rot *= Time.deltaTime;
        Trans *= Time.deltaTime;

        transform.Translate(0, 0, Trans * speed);
        transform.Rotate(0, Rot, 0);

        if((Trans != 0) && (!(Input.GetKey(KeyCode.LeftShift))) && (!(Input.GetKey(KeyCode.C))))
        {
            speed = 1.5F;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isSneaking", false);
        }

        else if ((Trans != 0) && ((Input.GetKey(KeyCode.LeftShift))) && (!(Input.GetKey(KeyCode.C))))
        {
            speed = 5.0F;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
            anim.SetBool("isSneaking", false);
        }

        else if ((Trans != 0) && (!(Input.GetKey(KeyCode.LeftShift))) && ((Input.GetKey(KeyCode.C))))
        {
            speed = 0.6F;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isSneaking", true);
        }

        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isSneaking", false);
        }
    }
}
