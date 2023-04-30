using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class depositBox : MonoBehaviour, IInteract
{
    public AudioSource itemPlace;
    public string prompt;
    private int count = 0;

    public string interactionPrompt { get { return prompt; } }

    public void interact(interactor interactor)
    {
        var player = interactor.GetComponent<playerMove>();
        if(player.hasItem)
        {
            player.hasItem = false;
            itemPlace.Play();
            prompt = "You have returned the item sucessfully.";
            count++;
            if(count == 3)
            {
                player.isDone = true;
            }

            //update the goal board
            //if board is empty, isDone = true
        }
        else
        {
            prompt = "You're not holding anything to deposit right now.";
        }
    }
}
