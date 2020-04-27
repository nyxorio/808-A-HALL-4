using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    [SerializeField] private int boba, teaBag, water, sugar, fruitJuice, milk;
    private string orderName;
    private Dictionary<string, int> order;

    [SerializeField] private GameObject nextCharacter;

    private void Start()
    {
        order = new Dictionary<string, int>();
        order.Add("Boba", boba);
        order.Add("Tea Bag", teaBag);
        order.Add("Water", water);
        order.Add("Sugar", sugar);
        order.Add("Fruit Juice", fruitJuice);
        order.Add("Milk", milk);
    }

    public void Receive(Dictionary<string, int> drink)
    {
        if (order.Keys.All(k => drink.ContainsKey(k) && object.Equals(order[k], drink[k])))
        {
            Debug.Log("Thank you!");

            if (nextCharacter == null)
            {
                GameObject.Find("Character List").GetComponent<LevelChange>().ChangeLevel();
                return;
            }

            nextCharacter.SetActive(true);
            name = "Character (Complete)";
            GameObject.Find("Drink").GetComponent<Drink>().NextOrder();
            gameObject.SetActive(false);
        }
        else
            Debug.Log("That's not my order ...");
    }
}
