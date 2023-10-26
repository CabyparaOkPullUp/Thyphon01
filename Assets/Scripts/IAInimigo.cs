using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    private float _velocidade = 6.0f;

    [SerializeField]
    private GameObject _explosaoDoInimigo;

    [SerializeField]
    private GameObject pupFlamethrower; // Prefab do item "pupFlamethrower"

    void Start()
    {
        // Configuração inicial, se necessário.
    }

    void Update()
    {
        // Move o inimigo para a esquerda
        transform.Translate(Vector3.right * _velocidade * Time.deltaTime);

        // Verifica se o inimigo saiu da tela pela esquerda
        if (transform.position.x < -8.0f)
        {
            // Reposiciona o inimigo na direita com uma posição Y aleatória
            float posY = UnityEngine.Random.Range(-6.4f, 6.4f);
            transform.position = new Vector3(8.0f, posY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.DanoAoPlayer();
            }
        }

        // Verifique se pupFlamethrower não é null e se tem um valor true antes de comparar.
        if (pupFlamethrower != null)
        {
            bool valorPupFlamethrower = pupFlamethrower.activeSelf;
            if (UnityEngine.Random.value < 0.3f && valorPupFlamethrower)
            {
                Instantiate(pupFlamethrower, transform.position, Quaternion.identity);
            }
        }
        
        // Probabilidade de 30% de drop do item "pupFlamethrower"
        if (pupFlamethrower != null && UnityEngine.Random.value < 0.3f)
        {
            Instantiate(pupFlamethrower, transform.position, Quaternion.identity);
        }

        // Destruir o inimigo após todas as verificações necessárias.
        Destroy(this.gameObject);
        Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);
    }
}