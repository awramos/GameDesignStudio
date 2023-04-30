using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactor : MonoBehaviour
{
    //this goes on the player

    public Transform cam;
    public float reach;
    bool active = false;
    public int count = 0;

    public GameObject textBox;
    public GameObject words;
    public Text wordsContent;

    private void Start()
    {
        textBox.SetActive(false);
        words.SetActive(false);
    }

    private void Update()
    {
        RaycastHit ray;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out ray, reach);
        if(Input.GetKeyDown(KeyCode.E) && active) //if something is in range and the button is pressed
        {            
            if(ray.transform.gameObject.layer == 6) //if it is on the interactable layer
            {
                var interactable = ray.transform.gameObject.GetComponent<IInteract>();
                interactable.interact(this); //call the interact thing on that object
                if(ray.transform.gameObject.tag != "door" && ray.transform.gameObject.tag != "hatch")
                {
                    speechBox(interactable);
                }                
            }
                
        }
    }

    private void speechBox(IInteract target)
    {
        wordsContent.text = target.interactionPrompt;
        textBox.SetActive(true);
        words.SetActive(true);
        StartCoroutine(popupWait());
    }

    IEnumerator popupWait()
    {
        yield return new WaitForSeconds(5);
        textBox.SetActive(false);
        words.SetActive(false);

    }
}