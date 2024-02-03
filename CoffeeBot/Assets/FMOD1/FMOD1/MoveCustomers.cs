using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCustomers : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walko", false);
        anim.SetBool("Leavo", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetBool("Walko", true);
            anim.Play("Walk");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetBool("Leavo", true);
            anim.Play("Leave");
        }
    }
}
