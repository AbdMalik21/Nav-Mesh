using UnityEngine;
 public class GranatBoom : MonoBehaviour
    {

        //AudioSource audio;
        public float delay = 3f;
        public float radius = 5f;
        public float force = 700f;
        public GameObject explodeEffect;
        //public AudioClip destroyFX;
        float countdown;
        bool explode = false;

        void Start()
        {
            //audio = GetComponent<AudioSource>();
            countdown = delay;
        }

        // Update is called once per frame
        void Update()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && !explode)
            {
                //audio.PlayOneShot(destroyFX, 1);
                Explode();
                explode = true;
            }
        }

        void Explode()
        {
            Instantiate(explodeEffect, transform.position, transform.rotation);

            Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in collidersToDestroy)
            {
                GrenadeDestroy dest = nearbyObject.GetComponent<GrenadeDestroy>();
                PlayerHealth ph = nearbyObject.GetComponent<PlayerHealth>();
                EnemyHealth eh = nearbyObject.GetComponent<EnemyHealth>();
                if (dest != null)
                {
                    dest.Destroy();
                }
                if (ph != null)
                {
                    ph.Destroy();
                }
                if (eh != null)
                {
                    eh.Destroy();
                }
            }

            Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in collidersToMove)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }

            if (gameObject != null) Destroy(gameObject);
        }
    }

