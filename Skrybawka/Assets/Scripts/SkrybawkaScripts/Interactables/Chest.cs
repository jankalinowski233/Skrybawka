using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public override void Interact()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Open");
    }
}
