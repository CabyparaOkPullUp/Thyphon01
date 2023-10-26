using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float tempoDeVida = 2.0f; // Tempo em segundos antes do tiro desaparecer
    public float velocFlamethrower = 12.0f;


    // Start is called before the first frame update
    void Start()
    {
        // Inicia a contagem regressiva para destruir o tiro
        Destroy(gameObject, tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocFlamethrower * Time.deltaTime);

        if (transform.position.y > 5.5f)
        {
            Destroy(this.gameObject);
        }
    }

}
