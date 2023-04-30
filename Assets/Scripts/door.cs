using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour, IInteract
{
    public Transform destination;

    public AudioSource doorLocked;
    public AudioSource doorUnlock;
    public AudioSource doorOpen;
    public AudioSource hatchOpen;
    public string prompt;

    public string interactionPrompt { get { return prompt; } }

    public void interact(interactor interactor)
    {
        var player = interactor.GetComponent<playerMove>();
        float newX = destination.position.x;
        float newY = destination.position.y;
        float newZ = destination.position.z;

        if (gameObject.tag == "needsKey")
        {
            if(player.hasKey)
            {
                player.hasKey = false;
                prompt = "You unlocked the door using the key you found.";
                doorUnlock.Play();
                StartCoroutine(popupWait());
                //gameManager.instance.player.trans.position = new Vector3(newX, .37f, newZ);
            }
            else
            {
                prompt = "This door is locked. Maybe there's a key somewhere.";
                doorLocked.Play();
            }
            return;
        }
        if (gameObject.tag == "exit")
        {
            if (player.isDone)
            {
                prompt = "All items have been returned. Thank you for your contributions. We hope to see you again soon.";
                StartCoroutine(endGameWait());
            }
            else
            {
                prompt = "There are still misplaced items in the various rooms. Find them and place them in the deposit box.";
            }
            return;
        }

        //standard door opening
        if (gameObject.tag == "hatch") //different sound for the hatch than other doors
        {
            hatchOpen.Play();
            gameManager.instance.player.trans.position = new Vector3(newX, .37f, newZ);
            return;
        }
        doorOpen.Play();
        gameManager.instance.player.trans.position = new Vector3(newX, .37f, newZ);
    }

    IEnumerator popupWait()
    {
        yield return new WaitForSeconds(1);
        gameObject.tag = "door";
    }

    IEnumerator endGameWait()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("gameEnd");
    }
}

