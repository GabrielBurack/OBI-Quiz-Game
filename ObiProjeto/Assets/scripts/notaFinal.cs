using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class notaFinal : MonoBehaviour
{
    private int idTema;

    public Text txtNota;
    public Text txtInfoTema;
    public Text txtInfoPerguntasCorretas;

    public GameObject[] estrela;
    private int nota;
    private int acertos;

    void Start()
    {
        estrela[0].SetActive(false);
        estrela[1].SetActive(false);
        estrela[2].SetActive(false);

        idTema = PlayerPrefs.GetInt("idTema");
        nota = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());

        txtNota.text = nota.ToString();
        txtInfoTema.text = "Você acertou " + acertos.ToString() + " de 5 questões";

        if (nota == 10)
        {
            estrela[0].SetActive(true);
            estrela[1].SetActive(true);
            estrela[2].SetActive(true);
        }
        else if (nota >= 7)
        {
            estrela[0].SetActive(true);
            estrela[1].SetActive(true);
            estrela[2].SetActive(false);
        }
        else if (nota >= 5)
        {
            estrela[0].SetActive(true);
            estrela[1].SetActive(false);
            estrela[2].SetActive(false);
        }

        string questoesCorretasStr = PlayerPrefs.GetString("questoesCorretas" + idTema.ToString(), "");
        Debug.Log("Questões corretas recuperadas: " + questoesCorretasStr);
        if (!string.IsNullOrEmpty(questoesCorretasStr))
        {
            txtInfoPerguntasCorretas.text = "Questões corretas: " + questoesCorretasStr;
        }
        else
        {
            txtInfoPerguntasCorretas.text = "Questões corretas: Nenhuma";
        }
    }

    public void jogarNovamente()
    {
        SceneManager.LoadScene("Tema" + idTema.ToString());
    }
}