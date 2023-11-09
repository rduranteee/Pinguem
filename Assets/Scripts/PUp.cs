using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PUp : MonoBehaviour
{
    [SerializeField]
    private float _velocidade = 3.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);
        if (transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("O objeto "+name+" colidiu com o objeto "+ other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.LigarPUDisparoTriplo();
            }

            StartCoroutine(player.DisparoTriploRotina());
            Destroy(this.gameObject);


        }


    }


}



