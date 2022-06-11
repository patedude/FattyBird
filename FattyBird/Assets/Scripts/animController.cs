using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;

    const int idle = 0;
    const int fly = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetInteger("state", fly);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetInteger("state", idle);
        }
    }
}
