using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class objektifScript : MonoBehaviour
{
    public GameObject finish;
    private Text coinText, targetText;
    string coin, target;
    bool isFinish = false;
    void Start()
    {
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        targetText = GameObject.Find("TargetText").GetComponent<Text>();
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("lastIndexScene", SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        coin = "" + coinText.text;
        target = "" + targetText.text;
        if (coin.Equals(target) && !isFinish)
        {
            //Debug.Log("muncul");
            //finish.SetActive(true);
            Instantiate(finish, transform.position, transform.rotation);
            isFinish = true;
        }
    }
}
