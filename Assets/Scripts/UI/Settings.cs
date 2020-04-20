using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private AudioSource music;

    void Start()
    {
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        GameObject.Find("Slider").GetComponent<Slider>().value = music.volume;
    }

    public void ChangeVolume(float vol)
    {
        music.volume = vol;
    }
}
