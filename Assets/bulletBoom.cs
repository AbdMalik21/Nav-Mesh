using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBoom : MonoBehaviour
{
    //AudioSource audio;
    public float delay = 100f;
    //public GameObject explodeEffect;
    //public AudioClip destroyFX;
    float countdown;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            //audio.PlayOneShot(destroyFX, 1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Instantiate(explodeEffect, transform.position, transform.rotation);
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.Destroy();
            }
        }
        if (gameObject != null) Destroy(gameObject);
    }
}
