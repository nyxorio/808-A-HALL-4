using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private Sprite smallPile, bigPile;
    private Text money;
    private int currentAmount;
    private static int totalMoney;

    private void Start()
    {
        money = GameObject.Find("Money Text").GetComponent<Text>();
        money.text = totalMoney.ToString();
        currentAmount = 0;
    }

    public void AddMoney(int amount)
    {
        currentAmount = Mathf.Max(0, currentAmount + amount);

        if (currentAmount < 15)
            GetComponent<Image>().sprite = smallPile;
        else
            GetComponent<Image>().sprite = bigPile;

        if (currentAmount > 0)
            GetComponent<Image>().enabled = true;
    }

    public void ChangeTotal(int amount)
    {
        totalMoney = Mathf.Max(0, totalMoney + amount);
        money.text = totalMoney.ToString();
    }

    public void OnClick()
    {
        if (currentAmount <= 0)
            return;

        totalMoney += currentAmount;
        money.text = totalMoney.ToString();
        currentAmount = 0;
        GetComponent<Image>().enabled = false;
    }
}
