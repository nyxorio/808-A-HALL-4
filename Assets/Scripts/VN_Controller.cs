using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_Controller : MonoBehaviour
{
    public void Continue()
    {
        GameObject currentCharacter = GameObject.Find("Character");
        GameObject nextCharacter = currentCharacter.GetComponent<NPC>().nextCharacter;
        if (nextCharacter == null)
            GameObject.Find("Character List").GetComponent<LevelChange>().ChangeLevel();
        else
        {
            currentCharacter.SetActive(false);
            nextCharacter.SetActive(true);
            GameObject.Find("Drink").GetComponent<Drink>().NextOrder(nextCharacter);
        }
    }
}
