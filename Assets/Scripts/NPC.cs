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
    private MilkTea order;
    private TextMeshProUGUI textBox;
    private Template_UIManager UIManager;

    public UnityEvent PayEvent;

    private void Start()
    {
        UIManager = GameObject.Find("UIMANAGER").GetComponent<Template_UIManager>();
        UIManager.Interact(GetComponent<VIDE_Assign>());

        order = GetComponentInChildren<MilkTea>();
        textBox = GameObject.Find("Character Text").GetComponent<TextMeshProUGUI>();
        textBox.text = "Hi! Can I have a " + topping + " " + order.name + " with " + milk + " % milk.";

        if (PayEvent == null)
            PayEvent = new UnityEvent();
    }
    
    public void Receive(Dictionary<string, int> drink)
    {
        if (order.CheckOrder(drink) && GameObject.Find("Blender").GetComponent<Blender>().toppings[drink["Topping"]] == topping && Mathf.Abs(drink["Milk"] - milk) < 10)
        {
            PayEvent.Invoke();
            UIManager.Jump(correctNode);
            //name = "Character (Complete)";
        }
        else
            UIManager.Jump(wrongNode);
    }
}
