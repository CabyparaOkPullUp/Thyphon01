using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IAInimigo : MonoBehaviour
{
    private float _velocidade = 6.0f;

    [SerializeField]
    private GameObject _explodindoInimigoPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _velocidade);
        if(transform.position.x < -13f)
        {
            transform.position = new Vector3(UnityEngine.Random.Range(9.5f, -9.5f), 7.0f, -3.95f);
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
        Destroy(this.gameObject);
        Instantiate(_explodindoInimigoPrefab, transform.position, Quaternion.identity);
    }
}