using System;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Mocha")
        {
            other.transform.position = transform.position;
            Animator anim = other.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("IsSleeping", true);
            }
        }
        
    }
}
