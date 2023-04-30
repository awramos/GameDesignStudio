using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour, IInteract
{
    public AudioSource itemGrab;
    public AudioSource keyGrab;
    public string prompt;

    public string interactionPrompt{ get { return prompt;  } }

    public void interact(interactor interactor)
    {
        var player = interactor.GetComponent<playerMove>();

        if (gameObject.tag == "goal")
        {
            if (player.hasItem)
            {
                prompt = "Your hands are already full.";
                return;
            }
            prompt = "You are now holding this item. Go to the hub and place it in the deposit box."; 
            player.hasItem = true;
            itemGrab.Play();
            Destroy(gameObject);
            return;
        }
        if (gameObject.tag == "key")
        {
            prompt = "You now have a key. Maybe you can use it somewhere.";
            player.hasKey = true;
            keyGrab.Play();
            Destroy(gameObject);
            return;
        }

        prompt = "This belongs here.";
        interactor.count += 1;
        if(interactor.count == 10)
        {
            prompt = "You're nosey, aren't you?";
        }
        if (interactor.count == 30)
        {
            prompt = "If you click enough, you HAVE to find the solution, right?";
        }
    }

}
