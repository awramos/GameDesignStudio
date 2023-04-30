using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteract
{
    public void interact(interactor interactor);

    public string interactionPrompt { get; }
}
