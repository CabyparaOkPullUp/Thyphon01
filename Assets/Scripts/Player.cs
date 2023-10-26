using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 0.0f;
    public float entradaHorizontal;
    public float entradaVertical;

    public GameObject pfFireball;
    public GameObject pfFlamethrower;

    public float tempoDeDisparoFireball = 0f;
    public float cadenciaFireball = 0.5f; // Tempo entre os disparos de pfFireball

    public float tempoDeDisparoFlamethrower = 0f;
    private bool dispararFlamethrower = false; // Indica se o jogador está disparando o flamethrower.

    public bool possoDarFlamethrower = false;
    public float duracaoFlamethrower = 5.0f; // Duração da pfFlamethrower
    private float tempoRestanteFlamethrower = 0f; // Tempo restante da pfFlamethrower

    public int vidas = 3;

    [SerializeField]
    private GameObject _explosaoPlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Start de " + this.name);
        velocidade = 3.0f;
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // ----

        Movimento();

        //-----
        // ...

        if (possoDarFlamethrower != null)
        {
            // Se a pfFlamethrower estiver ativa, atualize o tempo restante.
            if (tempoRestanteFlamethrower > 0)
            {
                tempoRestanteFlamethrower -= Time.deltaTime;

                // Verifique se o tempo da pfFlamethrower acabou e, se sim, desative a capacidade.
                if (tempoRestanteFlamethrower <= 0)
                {
                    possoDarFlamethrower = false;
                }
            }
        }

        // ...

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time > tempoDeDisparoFireball && !possoDarFlamethrower)
            {
                Instantiate(pfFireball, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity);
                tempoDeDisparoFireball = Time.time + cadenciaFireball;
            }

            // Ativar o flamethrower quando o jogador pressionar a tecla de ataque.
            if (possoDarFlamethrower)
            {
                dispararFlamethrower = true;
                // Iniciar o contador de tempo do flamethrower.
                tempoDeDisparoFlamethrower = Time.time;
            }
        }

        // Disparar o flamethrower enquanto a tecla de ataque estiver pressionada.
        if (dispararFlamethrower)
        {
            // Atualizar o tempo de disparo do flamethrower.
            float tempoAtual = Time.time;
            if (tempoAtual - tempoDeDisparoFlamethrower <= duracaoFlamethrower)
            {
                // Enquanto o tempo de disparo for menor ou igual à duração do flamethrower,
                // continue instanciando pfFlamethrower.
                Instantiate(pfFlamethrower, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity);
            }
            else
            {
                // Desativar o disparo do flamethrower quando o tempo do flamethrower acabar.
                dispararFlamethrower = false;
            }
        }

    }


    private void Movimento()
    {

        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * Time.deltaTime * velocidade * entradaHorizontal);

        if (transform.position.x > 9.85f)
        {
            transform.position = new Vector3(-9.85f, transform.position.y, 0);
        }

        if (transform.position.x < -9.85f)
        {
            transform.position = new Vector3(9.85f, transform.position.y, 0);

        }

        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velocidade * entradaVertical);

        if (transform.position.y > 7.0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.y < -3.95f)
        {
            transform.position = new Vector3(transform.position.x, -3.95f, 0);
        }

    }
    public IEnumerator FlamethrowerRotina()
    {
        yield return new WaitForSeconds(duracaoFlamethrower);
        possoDarFlamethrower = false;
    }


    public void LigarPUpFlamethrower()
    {
        possoDarFlamethrower = true;
        StartCoroutine(FlamethrowerRotina());
    }

    public void DanoAoPlayer()
    {
        // vidas = vidas - 1;
        vidas--;
        if (vidas < 1)
        {
            Destroy(this.gameObject);
        }
    }

}

