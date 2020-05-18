using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] public GameObject nextCharacter;
    [SerializeField] private int milk;
    [SerializeField] private string topping;
    [SerializeField] private int correctNode, wrongNode;
    [SerializeField] private Sprite characterArt;
    private MilkTea order;
    private UIManager UIManager;

    public UnityEvent PayEvent;

    private void Start()
    {
        UIManager = GameObject.Find("UIMANAGER").GetComponent<UIManager>();
        UIManager.Interact(GetComponent<VIDE_Assign>());

        order = GetComponentInChildren<MilkTea>();

        if (PayEvent == null)
            PayEvent = new UnityEvent();
    }
    
    public void Receive(Dictionary<string, int> drink)
    {
        if (order.CheckOrder(drink) && GameObject.Find("Blender").GetComponent<Blender>().toppings[drink["Topping"]] == topping && Mathf.Abs(drink["Milk"] - milk) <= 5)
        {
            PayEvent.Invoke();
            UIManager.Jump(correctNode);
        }
        else
            UIManager.Jump(wrongNode);
    }

    public void ToggleSprite()
    {
        if (GetComponent<SpriteRenderer>().sprite == null)
            GetComponent<SpriteRenderer>().sprite = characterArt;
        else
            GetComponent<SpriteRenderer>().sprite = null;
    }

    public void Continue()
    {
        if (nextCharacter == null)
            GameObject.Find("Character List").GetComponent<LevelChange>().ChangeLevel();
        else
        {
            nextCharacter.SetActive(true);
            GameObject.Find("Drink").GetComponent<Drink>().NextOrder(nextCharacter);
            gameObject.SetActive(false);
        }
    }
}
