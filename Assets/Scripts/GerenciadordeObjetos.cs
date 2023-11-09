using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadordeObjetos : MonoBehaviour
{
    [SerializeField]
    private GameObject _inimigoPrefab;

    [SerializeField]
    private GameObject[] _powerUps; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotinaGeracaoInimigo());
       
    }
    IEnumerator RotinaGeracaoInimigo()
    {
        while (1 == 1) ;
        {
            int powerUpsAletatorio = Random.Range(0, 3);
            Instantiate(_powerUps[powerUpsAletatorio], new Vector3(Random.Range(-7.7f, 7.7f), 6.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
        /*
        E porque estamos usando valores de 0 a 3 se o �ndice do array vai de 0 a
           2? Eu explico. Quando se trabalha com valores inteiros no Random.Range,
           ele sempre ir� retornar� um valor inteiro aleat�rio entre o m�nimo e o
           m�ximo exclusivo, o que significa que se coloc�ssemos como range os
valores (0, 2) a vari�vel powerUpsAleatorio s� receberia os valores 0 e 1.  
Por essa raz�o inserimos o valor m�nimo 0 e o m�ximo 3, dessa forma,
iremos obter ou valor 0 ou 1 ou 2, e esses valores se encaixam perfeitamente
nos valores do �ndice do array.
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
