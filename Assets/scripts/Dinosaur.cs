using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

[CommandPrefix("Dinosaur")]
public class Dinosaur : MonoBehaviour
{
    public void Idle()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("Howl", false);
        animator.SetBool("Scream", false);
    }
    [Command]
    public void Howl()
    {
        Idle();
        GetComponent<Animator>().SetBool("Howl", true);
    }

    [Command]
    public void Scream()
    {
        Idle();
        GetComponent<Animator>().SetBool("Scream", true);
    }
}
