using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class temaJogo : MonoBehaviour
{
    public int numeroQuestoes;

    public Button btnPlay;
    public Text txtNomeTema;

    public GameObject infoTema;
    public Text txtInfoTema;
    public GameObject[] estrela;

    public string[] nomeTema;
    private int idTema;
   
    void Start()
    {
        idTema = 0;
        txtNomeTema.text = nomeTema[idTema];
        txtInfoTema.text = "você acertou X de X questões";
        infoTema.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            estrela[i].SetActive(false);
        }

        btnPlay.interactable = false;
    }

    public void selecioneTema(int i)
    {
        estrela[0].SetActive(false);
        estrela[1].SetActive(false);
        estrela[2].SetActive(false);

        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        int acertos = PlayerPrefs.GetInt("acertos" + idTema.ToString());

        if (notaFinal == 10)
        {
            estrela[0].SetActive(true);
            estrela[1].SetActive(true);
            estrela[2].SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela[0].SetActive(true);
            estrela[1].SetActive(true);
            estrela[2].SetActive(false);
        }
        else if (notaFinal >= 5)
        {
            estrela[0].SetActive(true);
            estrela[1].SetActive(false);
            estrela[2].SetActive(false);
        }

        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
        txtNomeTema.text = nomeTema[idTema];

        txtInfoTema.text = "você acertou "+acertos.ToString()+" de "+numeroQuestoes.ToString()+" questões";
        infoTema.SetActive(true);
        btnPlay.interactable = true;
    }

    public void jogar()
    {
        SceneManager.LoadScene("Tema" + idTema.ToString());
    }
}
