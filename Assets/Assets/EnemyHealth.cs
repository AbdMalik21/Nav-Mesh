using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
    {
        public int nyawa = 5;
        private int isi;
        //public AudioClip takeItem;//, takeDamage, Die;
        AudioSource audio;

        void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public void Destroy()
        {
            nyawa--;
            if (nyawa > 0)
            {
                //Vector3 sementara = transform.position;
                //sementara.y += 1;
                //audio.PlayOneShot(takeDamage);
                //health.GetComponent<Text>().text = " " + nyawa;
                //Instantiate(bleedEffect, sementara, transform.rotation);
            }
            else
            {
                //audio.PlayOneShot(Die);
                //Instantiate(explodeEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

