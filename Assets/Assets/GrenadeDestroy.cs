using UnityEngine;
    public class GrenadeDestroy : MonoBehaviour
    {
        public GameObject explodeEffect;
        AudioSource audio;
        //public AudioClip destroyFX;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public void Destroy()
        {
            //audio.PlayOneShot(destroyFX);
            Instantiate(explodeEffect, transform.position, transform.rotation);
            if (gameObject != null) Destroy(gameObject);
        }
    }

