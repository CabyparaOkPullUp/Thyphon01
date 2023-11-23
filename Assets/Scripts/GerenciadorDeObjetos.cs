using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObjetos : MonoBehaviour
{

    [SerializeField]
    private GameObject _inimigoPrefab;

    [SerializeField]
    private GameObject[] _powerUpsPrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotinaGeracaoInimigo());
    }

    IEnumerator RotinaGeracaoInimigo()
    {
        while (1 == 1)
        {
            Instantiate(_inimigoPrefab, new Vector3(Random.Range(9.5f, -9.5f), 7.0f, -3.95f), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
    IEnumerator RotinaGeracaoPowerUp()
    {
        while (1 == 1)
        {
            int powerUpsAletatorio = Random.Range(0, 3);
            Instantiate(_powerUpsPrefab[powerUpsAletatorio], new Vector3(Random.Range(9.5f, -9.5f), 7.0f, -3.95f), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }

    }
}