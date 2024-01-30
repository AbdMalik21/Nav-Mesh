using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishTrigger : MonoBehaviour
{
    public GameObject win;
    protected Canvas m_canvas;
    bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        m_canvas = GameObject.Find("UI").GetComponent<Canvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!finish)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("WinScene");
                //var popup = Instantiate(win) as GameObject;
                //popup.SetActive(true);
                //popup.transform.localScale = Vector3.zero;
                //popup.transform.SetParent(m_canvas.transform, false);
                //finish = true;
            }
        }
    }
}
