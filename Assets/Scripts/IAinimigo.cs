using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IAinimigo : MonoBehaviour
{
    // Start is called before the first frame update

    private float _velocidade = 2.9f;

    [SerializeField]
    private GameObject _explosaoDoInimigo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);

        if ( transform.position.x < -9.9f)
        {
            transform.position = new Vector3(Random.Range(-9.9f, 2.0f), 2.0f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);

        }
       if ( other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.DanoAoPlayer();
            }
            Destroy(this.gameObject);

            Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);
        }
    }

}

