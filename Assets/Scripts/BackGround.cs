using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Variavel para controlar a velocidade do objeto BF
    public float velocidade = 1.0f;
    // Variavel para controle do ponto de reposicao
    public float reposicao = 7.20f ;
    //Variavel para guardar a posicao inicial do objeto
    public Vector3 posicaoInicial;

    // Start is called before the first frame update
    void Start()
    {
      posicaoInicial = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        float novoPosicao = Mathf.Repeat(Time.time * velocidade,reposicao);
        transform.position = posicaoInicial + Vector3.left * novoPosicao;
    }
}
