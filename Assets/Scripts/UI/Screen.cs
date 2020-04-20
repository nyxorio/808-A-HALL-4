using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    Color temp;
    float alpha = .3f;

    private void Start()
    {
        temp = gameObject.GetComponent<Image>().color;
    }

    public void TakeDamage()
    {
        StartCoroutine(RedFlash());
    }

    IEnumerator RedFlash()
    {
        for (float i = 0; i <= alpha; i+=.02f)
        {
            temp.a = i;
            gameObject.GetComponent<Image>().color = temp;
            yield return new WaitForSeconds(.001f);
        }

        for (float i = alpha; i >= 0; i-=.02f)
        {
            temp.a = i;
            gameObject.GetComponent<Image>().color = temp;
            yield return new WaitForSeconds(.001f);
        }
    }
}
