using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MilkTea : MonoBehaviour
{
    [SerializeField] private GameObject drinkList;

    [SerializeField] private int boba, teaBag, water, sugar, fruitJuice, milk;
    private Dictionary<string, int> order;

    // Start is called before the first frame update
    void Start()
    {
        order = new Dictionary<string, int>();
        order.Add("Boba", boba);
        order.Add("Tea Bag", teaBag);
        order.Add("Water", water);
        order.Add("Sugar", sugar);
        order.Add("Fruit Juice", fruitJuice);
    }

    override
    public string ToString()
    {
        string temp = name + "\n|";

        foreach (KeyValuePair<string, int> item in order)
            temp += "| " + item.Key + ": " + item.Value + " ";

        return temp + "| Milk: " + milk + "\n\n";
    }

    public bool CheckOrder(Dictionary<string, int> drink)
    {
        return order.Keys.All(k => drink.ContainsKey(k) && object.Equals(order[k], drink[k]) && Mathf.Abs(drink["Milk"] - milk) < 10);
    }
}
