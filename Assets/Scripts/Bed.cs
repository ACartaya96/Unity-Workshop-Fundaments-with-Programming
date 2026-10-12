using System;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Mocha")
        {
            other.transform.position = transform.position;
            if (other.TryGetComponent<Animator>(out Animator anim))
            {
                anim.SetBool("IsSleeping", true);
            }
        }
        
    }
}
