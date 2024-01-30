using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class exitGame : MonoBehaviour
{
    private AudioSource[] allAudioSources;
    private string sceneName;
    private Text levelText;
    void Start(){
        sceneName = PlayerPrefs.GetString("lastLoadedScene");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    void Update(){
        if(levelText != null){
            levelText.GetComponent<Text>().text = "" + sceneName;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    public void Retry(){
        SceneManager.LoadScene(sceneName);
    }

    public void NextLevel(){
        int indexLv = PlayerPrefs.GetInt("lastIndexScene");
        SceneManager.LoadScene(indexLv + 1);
    }
}
