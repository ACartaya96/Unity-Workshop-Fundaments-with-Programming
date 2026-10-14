using System;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Mocha")
        {
            other.transform.position = transform.position;
            Animator anim = other.GetComponentInChildren<Animator>();
            Mocha mocha = other.GetComponent<Mocha>();
            if (anim != null && mocha.mSleepy)
            {
                anim.SetBool("IsSleeping", true);
                StartCoroutine(NeedsManager.Instance.SleepRoutine());
            }
        }
        
    }
}
