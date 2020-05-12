using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MilkTea : MonoBehaviour
{
    //[SerializeField] private readonly GameObject drinkList;
    [SerializeField] private List<Sprite> toppings;

    [SerializeField] private int tea, matcha, sugar, fruitJuice;
    public Dictionary<string, int> order;

    void Awake()
    {
        order = new Dictionary<string, int>
        {
            { "Tea", tea },
            { "Matcha", matcha },
            { "Sugar", sugar },
            { "Fruit Juice", fruitJuice }
        };
    }

    override public string ToString()
    {
        string temp = name + "\n|";

        foreach (KeyValuePair<string, int> item in order)
            temp += "| " + item.Key + ": " + item.Value + " ";

        return temp + "\n\n";
    }

    public bool CheckOrder(Dictionary<string, int> drink)
    {
        return order.Keys.All(k => drink.ContainsKey(k) && object.Equals(order[k], drink[k]));
    }

    public Sprite GetImage(int topping)
    {
        return toppings[topping];
    }
}
