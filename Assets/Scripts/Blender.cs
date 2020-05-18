using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Blender : MonoBehaviour
{
    [SerializeField] private GameObject drinkList;
    [SerializeField] private GameObject drink;
    [SerializeField] public List<string> toppings;
    [SerializeField] private Sprite garbage;

    private Slider milk;
    private Coins money;

    private Dictionary<string, int> mix = new Dictionary<string, int>();
    private int counter = 0;
    private Image[] meter;
    private bool ready;

    private void Start()
    {
        ready = false;
        milk = GameObject.Find("Slider").GetComponent<Slider>();
        money = GameObject.Find("Coins").GetComponent<Coins>();

        meter = new Image[6];
        int i = 0;
        foreach (Image img in GameObject.Find("Ingredient Meter").GetComponentsInChildren<Image>())
            meter[i++] = img;

        foreach (Ingredient ingredient in GameObject.Find("Ingredient List").GetComponentsInChildren<Ingredient>())
            mix.Add(ingredient.GetIngredient(), 0);
        mix.Add("Milk", 0);
        mix.Add("Topping", 0);

        MeterUpdate();
    }

    public void Add(string name)
    {
        if (counter >= 6)
            return;

        mix[name]++;
        counter++;
        MeterUpdate();
    }

    public void BootUp()
    {
        ready = true;
    }

    public void Shutdown()
    {
        ready = false;
    }

    private void MeterUpdate()
    {
        for (int i = 0; i < counter; i++)
            meter[i].color = Color.gray;
        for (int i = counter; i < meter.Length; i++)
            meter[i].color = Color.white;
    }

    public void Reset()
    {
        foreach (string item in mix.Keys.ToList())
            mix[item] = 0;
        counter = 0;
        MeterUpdate();
    }

    public void Mix()
    {
        if (counter == 0 || !ready)
        {
            Reset();
            return;
        }

        mix["Milk"] = (int)milk.value;
        bool correct = false;

        foreach (MilkTea mt in drinkList.GetComponentsInChildren<MilkTea>())
            if (mt.CheckOrder(mix))
            {
                drink.GetComponent<SpriteRenderer>().sprite = mt.GetImage(0);
                int current = 0;
                for (int i = toppings.Count - 1; i > 0; i--)
                    if (mix[toppings[i]] > current)
                    {
                        drink.GetComponent<SpriteRenderer>().sprite = mt.GetImage(i);
                        mix["Topping"] = i;
                        break;
                    }

                correct = true;
                break;
            }

        if (!correct)
        {
            drink.GetComponent<SpriteRenderer>().sprite = garbage;
            mix["Topping"] = 0;
        }

        money.ChangeTotal(-1);
        drink.GetComponent<Drink>().SetMix(mix);
        drink.GetComponent<Collider2D>().enabled = true;
        Reset();
    }
}
