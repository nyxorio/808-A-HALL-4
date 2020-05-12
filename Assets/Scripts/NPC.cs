using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject nextCharacter;
    [SerializeField] private int milk;
    [SerializeField] private string topping;
    private MilkTea order;
    private TextMeshProUGUI textBox;

    public UnityEvent PayEvent;

    private void Start()
    {
        order = GetComponentInChildren<MilkTea>();
        textBox = GameObject.Find("Character Text").GetComponent<TextMeshProUGUI>();
        textBox.text = "Hi! Can I have a " + topping + " " + order.name + " with " + milk + " % milk.";

        if (PayEvent == null)
            PayEvent = new UnityEvent();
    }
    
    public System.Collections.IEnumerator Receive(Dictionary<string, int> drink)
    {
        if (order.CheckOrder(drink) && GameObject.Find("Blender").GetComponent<Blender>().toppings[drink["Topping"]] == topping && Mathf.Abs(drink["Milk"] - milk) < 10)
        {
            textBox.text = "Thank you!";
            PayEvent.Invoke();
            yield return new WaitForSeconds(3);

            if (nextCharacter == null)
                GetComponentInParent<LevelChange>().ChangeLevel();

            else {
                nextCharacter.SetActive(true);
                name = "Character (Complete)";
                GameObject.Find("Drink").GetComponent<Drink>().NextOrder();
                gameObject.SetActive(false);
            }
        }
        else
        {
            textBox.text = "...";
            yield return new WaitForSeconds(1);
            textBox.text = "That's not my order ... I ordered a " + topping + " " + order.name + " with " + milk + "% milk.";
        }
    }
}
