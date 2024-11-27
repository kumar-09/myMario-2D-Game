using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public void SetVolume()
    {
        audioMixer.SetFloat("volume", volumeSlider.value);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
