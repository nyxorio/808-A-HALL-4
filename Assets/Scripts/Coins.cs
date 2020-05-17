using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private Sprite smallPile, bigPile;
    private Text money;
    private int currentAmount;

    private void Start()
    {
        money = GameObject.Find("Money Text").GetComponent<Text>();
        currentAmount = 0;
    }

    public void AddMoney(int amount)
    {
        currentAmount += amount;

        if (currentAmount < 15)
            GetComponent<Image>().sprite = smallPile;
        else
            GetComponent<Image>().sprite = bigPile;

        GetComponent<Image>().enabled = true;
    }

    public void OnClick()
    {
        if (currentAmount <= 0)
            return;

        money.text = (int.Parse(money.text) + currentAmount).ToString();
        currentAmount = 0;
        GetComponent<Image>().enabled = false;
    }
}
