using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public float velocidade = 0.0f;
    public float entradaHorizontal;
    public float entradaVertical;

    public GameObject Laser;

    public float tempoDeDisparo = 0.3f;

    public float podeDisparar = 0.0f;

    public bool possoDarDisparoTriplo = false;

    public GameObject _disparoTriploPrefab;

    public int vidas = 3;

    [SerializeField]
    private GameObject _explosaoPlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start de " + this.name);
        velocidade = 4.0f;
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // ---

        Movimento();


        // ---

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {

            if (Time.time > podeDisparar) {

                if (possoDarDisparoTriplo == true) {

                    Instantiate(_disparoTriploPrefab, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);

                } else {

                    Instantiate(Laser, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);


                }
                podeDisparar = Time.time + tempoDeDisparo;

            }


        }


    }

    public IEnumerator DisparoTriploRotina()
    {
        yield return new WaitForSeconds(7.0f);
        possoDarDisparoTriplo = false;
    }

    public void LigarPUDisparoTriplo()
    {
        possoDarDisparoTriplo = true;

        StartCoroutine(DisparoTriploRotina());
    }



    private void Movimento() {

        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * entradaHorizontal);

        if (transform.position.x > 9.85f) {
            transform.position = new Vector3(-9.85f, transform.position.y, 0);
        }

        if (transform.position.x < -9.85f) {
            transform.position = new Vector3(9.85f, transform.position.y, 0);

        }

        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velocidade * entradaVertical);

        if (transform.position.y > 9.85f) {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.y < -3.2f) {
            transform.position = new Vector3(transform.position.x, -3.2f, 0);
        }

    }
    public void DanoAoPlayer()
    {
        // vidas = vidas -1;
        vidas--;
        if (vidas < 1)
        {
           Instantiate(_explosaoPlayerPrefab,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}


    

  


