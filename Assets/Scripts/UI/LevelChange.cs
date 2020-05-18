using UnityEngine;
using UnityEngine.SceneManagement;
using VIDE_Data;

public class LevelChange : MonoBehaviour
{
    public void ChangeLevel()
    {
        // End Scene loops back to Start Scene
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            return;
        }

        GameObject money = GameObject.Find("Coins");
        if (money != null)
            money.GetComponent<Coins>().OnClick();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}