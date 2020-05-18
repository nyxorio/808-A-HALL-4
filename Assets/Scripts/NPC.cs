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
    private Template_UIManager UIManager;

    public UnityEvent PayEvent;

    private void Start()
    {
        UIManager = GameObject.Find("UIMANAGER").GetComponent<Template_UIManager>();
        UIManager.Interact(GetComponent<VIDE_Assign>());

        order = GetComponentInChildren<MilkTea>();

        if (PayEvent == null)
            PayEvent = new UnityEvent();
    }
    
    public void Receive(Dictionary<string, int> drink)
    {
        if (order.CheckOrder(drink) && GameObject.Find("Blender").GetComponent<Blender>().toppings[drink["Topping"]] == topping && Mathf.Abs(drink["Milk"] - milk) < 10)
        {
            PayEvent.Invoke();
            UIManager.Jump(correctNode);
        }
        else
            UIManager.Jump(wrongNode);
    }

    public void ShowImage()
    {
        GetComponent<SpriteRenderer>().sprite = characterArt;
    }

    public void HideImage()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
