using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDeUI : MonoBehaviour
{
    public Sprite[] vidas;
    public Image mostrarImagemDasVidas;
    private int _placar = 0;
    public Text textoDoPLacar;
    public void AtualizaVidas(int vidasAtuais)
    {
        mostrarImagemDasVidas.sprite = vidas[vidasAtuais];
    }

    public void AtualizaPlacar()
    {
        _placar = _placar + 100;
        textoDoPLacar.text = "PLACAR: " + _placar.ToString();
    }
}
