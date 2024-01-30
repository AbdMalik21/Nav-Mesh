using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
    {
        public GameObject health;// explodeEffect, bleedEffect, 
        private int nyawa = 5, isi;
        private Text coinText, ammoText;
        private string convert = "";
        public AudioClip takeItem;//, takeDamage, Die;
        AudioSource audio;

        void Start()
        {
            health.GetComponent<Text>().text = " " + nyawa;
            coinText = GameObject.Find("CoinText").GetComponent<Text>();
            ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
            audio = GetComponent<AudioSource>();
        }

        void Update()
        {

        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Coin")
            {
                audio.PlayOneShot(takeItem);
                convert = coinText.text;
                isi = int.Parse("" + convert);
                isi += 1;
                coinText.GetComponent<Text>().text = "" + isi;
                Destroy(collision.gameObject);
                convert = "";
            }

            if (collision.tag == "Grenade")
            {
                audio.PlayOneShot(takeItem);
                convert = ammoText.text;
                isi = int.Parse("" + convert);
                isi += 1;
                ammoText.GetComponent<Text>().text = "" + isi;
                Destroy(collision.gameObject);
                convert = "";
            }
        }

        public void Destroy()
        {
            nyawa--;
            if (nyawa > 0)
            {
                Vector3 sementara = transform.position;
                sementara.y += 1;
                //audio.PlayOneShot(takeDamage);
                health.GetComponent<Text>().text = " " + nyawa;
                //Instantiate(bleedEffect, sementara, transform.rotation);
            }
            else
            {
                //audio.PlayOneShot(Die);
                //Instantiate(explodeEffect, transform.position, transform.rotation);
                //Destroy(gameObject);
                //Time.timeScale = 0f;
                SceneManager.LoadScene("LoseScene");
            }
        }
    }

