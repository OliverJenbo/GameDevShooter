using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //message displayed to player when looking at an interactable object.
    public string promptmessage;

    //this function will be called from the player
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        
    }
}