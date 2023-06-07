using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject AudioManager;
    // Settings
    public Toggle FullscreenToggle;
    //public TMP_Text Counter; //wylaczone ale dziala
    public AudioMixer Mixer;
    public Slider AudioSlider;               // odwo³anie do slidera odpowiadaj¹cego za g³oœnoœæ aplikacji
    public TMP_Dropdown ResolutionsDropDown; // odwo³anie do dropboxa z rozdzielczoœciami
    public Resolution[] resolutions;         // lista rozdzielczoœci
    void Start()
    {
        AudioSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        Resolution();           // funkcja przypisuj¹ca rozdzielczoœci do dropboxa
        GameObject Audioobj = GameObject.FindWithTag("AudioManager");
        if (Audioobj == null) {
            Instantiate(AudioManager); }
        if (PlayerPrefs.HasKey("SaveVolume"))  {
            AudioSlider.value = PlayerPrefs.GetFloat("SaveVolume");
            Audio(); ;
        } else {
            Audio();
        }
    }
    // Main
    private void Update() {
        //Audio();
    } public void Play() {
        SceneManager.LoadScene(+1); // ³adujê scene wypisan¹ w ("")
    } public void Exit() {
        Application.Quit(); // wy³¹cza aplikacje
    }
    public void Audio()
    {
        float volume = AudioSlider.value;
        Mixer.SetFloat("Volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SaveVolume", volume);
        string countertext = volume.ToString();
        //Counter.text = countertext; //wylaczone ale dziala
    }
    public void Fullscreen()    // nie dzia³a w runtime
    {
        if (Screen.fullScreenMode == FullScreenMode.FullScreenWindow) { // sprawdza czy jest w fullscreen czy w okienku, je¿eli jest w fullscreen wykona siê to
            FullscreenToggle.isOn = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;    // ustawia okienko
        } else {   // je¿eli aplikacja jest w okienku wykona siê to
            FullscreenToggle.isOn = true;
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;    // ustawia fullscreen
        }
    }
    void Resolution()
    {
        resolutions = Screen.resolutions;   // przypisuje odwo³anie resolutions do rozdzielczoœci aplikacji
        List<string> options = new List<string>();
        int currentResolutionIndex = 0; //
        for(int i =0; i < resolutions.Length; i++)  // pêtla
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;   // ustawia zmienn¹ (options) na rozdzielczoœci
            options.Add(option); // 
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) // sprawdza czy podana rozdzielczoœæ zgadza siê z rozdzielczoœci¹ aplikacji
            {
                currentResolutionIndex = i; // przypisuje index dla rozdzielczoœci
            }
        }
        ResolutionsDropDown.AddOptions(options);            // dodaje opcje do dropboxa
        ResolutionsDropDown.value = currentResolutionIndex; // przypisuje index aktualnie wybranej opcji
        ResolutionsDropDown.RefreshShownValue();            // ustawia odœwie¿anie ekranu
    }
    public void Apply(int resolutionIndex)
    {
        //resolution
        resolutionIndex = ResolutionsDropDown.value; // przypisuje lokalnej zmiennej index opcji wybranej z listy
        Resolution resolution = resolutions[resolutionIndex]; // rozdzielczoœæ = index lokalnej zminennej
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // rozdzielczoœæ ekranu = rozdzielczoœæ powi¹zana z indexem
        //resolution
    }
    //ingamemenu
    public void Pause()
    {
        Time.timeScale = 0;
        if (Time.timeScale == 0) { Debug.Log("Paused"); }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        if (Time.timeScale == 1) { Debug.Log("UnPaused"); }
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ValueChangeCheck() 
    {
        Audio();
    }
}
