using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueBox : MonoBehaviour
{
    public Template_UIManager UIManager;
    public VIDE_Assign character;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UIManager.Interact(character);
        }
    }
}
