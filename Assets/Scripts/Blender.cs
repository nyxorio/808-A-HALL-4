using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Blender : MonoBehaviour
{
    [SerializeField] private GameObject drink;
    private Slider milk;

    private Dictionary<string, int> mix = new Dictionary<string, int>();
    private int counter = 0;
    private Image[] meter;

    private void Start()
    {
        milk = GameObject.Find("Slider").GetComponent<Slider>();

        meter = new Image[6];
        int i = 0;
        foreach (Image img in GameObject.Find("Ingredient Meter").GetComponentsInChildren<Image>())
            meter[i++] = img;

        foreach (Ingredient ingredient in GameObject.Find("Ingredient List").GetComponentsInChildren<Ingredient>())
            mix.Add(ingredient.GetIngredient(), 0);

        MeterUpdate();
    }

    public void Add(string name)
    {
        mix[name]++;
        counter++;
        MeterUpdate();
    }

    private void MeterUpdate()
    {
        for (int i = 0; i < counter; i++)
            meter[i].color = Color.gray;
        for (int i = counter; i<meter.Length; i++)
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

        Dictionary<string, int> temp = new Dictionary<string, int>();

        temp.Add("Boba", 1);
        temp.Add("Tea Bag", 2);
        temp.Add("Water", 2);
        temp.Add("Sugar", 1);
        temp.Add("Fruit Juice", 0);
        temp.Add("Milk", 50);

        if (mix.Keys.All(k => temp.ContainsKey(k) && object.Equals(mix[k], temp[k])) && Mathf.Abs(temp["Milk"] - milk.value) < 10)
        {
            Dictionary<string, int> copy = new Dictionary<string, int>(mix);
            copy.Add("Milk", temp["Milk"]);
            drink.SetActive(true);
            //drink.GetComponent<Drink>().SetName(temp.name);
            drink.GetComponent<Drink>().SetMix(copy);
        }

        Reset();
    }
}
