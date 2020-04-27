using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    public void Toggle()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
