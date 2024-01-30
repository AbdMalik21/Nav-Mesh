using UnityEngine;
using UnityEngine.UI;

    public class GrenadeThrow : MonoBehaviour
    {
        public GameObject Granat, Player, Amunisi, throwEffect;
        public float throwForce = 200f;
        private int isi;
        private Text text;
        private string convert = "";
        AudioSource audio;
        public AudioClip throwFX;

        void Start()
        {
            audio = GetComponent<AudioSource>();
        }

    public void PutBomb()
    {
        if (Amunisi.GetComponent<Text>().text.Equals("0"))
        {
            //Debug.Log("Habis");
        }
        else
        {
            audio.PlayOneShot(throwFX);
            convert = "" + Amunisi.GetComponent<Text>().text.ToString();
            isi = int.Parse(convert);
            isi--;
            Amunisi.GetComponent<Text>().text = "" + isi;
            //Debug.Log("Lempar");
            //Vector3 lemparan = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 1.6f);
            //Debug.Log(lemparan);
            GameObject granat = Instantiate(Granat, Player.transform.position, transform.rotation);
            Instantiate(throwEffect, Player.transform.position, transform.rotation);
            //Rigidbody rb = granat.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
            //Debug.Log(isi);
        }
    }
    }

