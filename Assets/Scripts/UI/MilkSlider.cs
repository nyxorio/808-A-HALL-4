using UnityEngine;
using UnityEngine.UI;

public class MilkSlider : MonoBehaviour
{
    public void ChangeValue(string change)
    {
        int result = Mathf.Min(Mathf.Max(0, int.Parse(change)), 100);

        GetComponent<Slider>().value = result;
        GameObject.Find("Milk InputField").GetComponent<TMPro.TMP_InputField>().text = result.ToString();
    }
}
