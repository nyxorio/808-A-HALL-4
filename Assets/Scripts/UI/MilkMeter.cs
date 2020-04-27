using UnityEngine;
using TMPro;

public class MilkMeter : MonoBehaviour
{
    public void ChangeValue(float s)
    {
        GetComponent<TMP_InputField>().text = s.ToString();
    }
}