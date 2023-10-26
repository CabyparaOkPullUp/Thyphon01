using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PUpFlamethrower : MonoBehaviour
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.LigarPUpFlamethrower();
            }
            Destroy(this.gameObject);
        }


    }
    
}