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
    public Slider AudioSlider;               // odwo�anie do slidera odpowiadaj�cego za g�o�no�� aplikacji
    public TMP_Dropdown ResolutionsDropDown; // odwo�anie do dropboxa z rozdzielczo�ciami
    public Resolution[] resolutions;         // lista rozdzielczo�ci
    void Start()
    {
        AudioSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        Resolution();           // funkcja przypisuj�ca rozdzielczo�ci do dropboxa
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
        SceneManager.LoadScene(+1); // �aduj� scene wypisan� w ("")
    } public void Exit() {
        Application.Quit(); // wy��cza aplikacje
    }
    public void Audio()
    {
        float volume = AudioSlider.value;
        Mixer.SetFloat("Volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SaveVolume", volume);
        string countertext = volume.ToString();
        //Counter.text = countertext; //wylaczone ale dziala
    }
    public void Fullscreen()    // nie dzia�a w runtime
    {
        if (Screen.fullScreenMode == FullScreenMode.FullScreenWindow) { // sprawdza czy jest w fullscreen czy w okienku, je�eli jest w fullscreen wykona si� to
            FullscreenToggle.isOn = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;    // ustawia okienko
        } else {   // je�eli aplikacja jest w okienku wykona si� to
            FullscreenToggle.isOn = true;
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;    // ustawia fullscreen
        }
    }
    void Resolution()
    {
        resolutions = Screen.resolutions;   // przypisuje odwo�anie resolutions do rozdzielczo�ci aplikacji
        List<string> options = new List<string>();
        int currentResolutionIndex = 0; //
        for(int i =0; i < resolutions.Length; i++)  // p�tla
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;   // ustawia zmienn� (options) na rozdzielczo�ci
            options.Add(option); // 
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) // sprawdza czy podana rozdzielczo�� zgadza si� z rozdzielczo�ci� aplikacji
            {
                currentResolutionIndex = i; // przypisuje index dla rozdzielczo�ci
            }
        }
        ResolutionsDropDown.AddOptions(options);            // dodaje opcje do dropboxa
        ResolutionsDropDown.value = currentResolutionIndex; // przypisuje index aktualnie wybranej opcji
        ResolutionsDropDown.RefreshShownValue();            // ustawia od�wie�anie ekranu
    }
    public void Apply(int resolutionIndex)
    {
        //resolution
        resolutionIndex = ResolutionsDropDown.value; // przypisuje lokalnej zmiennej index opcji wybranej z listy
        Resolution resolution = resolutions[resolutionIndex]; // rozdzielczo�� = index lokalnej zminennej
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // rozdzielczo�� ekranu = rozdzielczo�� powi�zana z indexem
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
