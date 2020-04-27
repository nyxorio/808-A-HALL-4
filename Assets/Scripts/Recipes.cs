using UnityEngine;
using TMPro;

public class Recipes : MonoBehaviour
{
    [SerializeField] private GameObject drinkList;
    private TextMeshProUGUI textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        foreach (MilkTea mt in drinkList.GetComponentsInChildren<MilkTea>())
            textBox.text += mt.ToString();
    }
}
