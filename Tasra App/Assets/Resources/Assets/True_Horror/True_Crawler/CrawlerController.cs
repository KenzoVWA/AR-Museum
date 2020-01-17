using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerController : MonoBehaviour
{
    static Animator anim;
    CharacterController controller;
    public float speed = 1.0F;
    public float rotationSpeed = 100.0F;
    float elapsedTime = Mathf.Infinity;
    public float duration;
    Vector3 moveDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        elapsedTime = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isRunning") && elapsedTime < 1) {
            moveDir = new Vector3(1, 0, 0);
            moveDir *= speed;
            controller.Move(moveDir * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }

        else  if (anim.GetBool("isRunning") && elapsedTime < duration)
        {
            moveDir = new Vector3(1, 0, 0);
            moveDir *= speed;
            controller.Move(moveDir * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= duration)
        {
            anim.SetBool("isRunning", false);
        }

    }
}
