using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject nextCharacter;
    private MilkTea order;

    private void Start()
    {
        order = GetComponentInChildren<MilkTea>();
    }

    public void Receive(Dictionary<string, int> drink)
    {
        if (order.CheckOrder(drink))
        {
            Debug.Log("Thank you!");

            if (nextCharacter == null)
            {
                GetComponentInParent<LevelChange>().ChangeLevel();
                return;
            }

            nextCharacter.SetActive(true);
            name = "Character (Complete)";
            GameObject.Find("Drink").GetComponent<Drink>().NextOrder();
            gameObject.SetActive(false);
        }
        else
            Debug.Log("That's not my order ... I ordered a " + order.name + ".");
    }
}
