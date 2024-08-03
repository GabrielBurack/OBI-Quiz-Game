using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{
    private int idTema;

    public Text pergunta;
    public Text respostaA, respostaB, respostaC, respostaD, respostaE;
    public Text infoRespostas;

    public string[] perguntas;      //armazena todas as perguntas   
    public string[] alternativaA;   //armazena todas as alternativas A
    public string[] alternativaB;   //armazena todas as alternativas B
    public string[] alternativaC;   //armazena todas as alternativas C
    public string[] alternativaD;   //armazena todas as alternativas D
    public string[] alternativaE;   //armazena todas as alternativas E
    public string[] corretas;       //armazena todas as alternativas corretas

    private int idPergunta, notaFinal;

    private float acertos, questoes, media;

    public Button buttonA, buttonB, buttonC, buttonD, buttonE;
    public Sprite spriteCorreto;
    public Sprite spriteIncorreto;
    public Sprite spritePadrao;

    private List<int> questoesCorretas = new List<int>();

    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;

        PlayerPrefs.SetString("questoesCorretas" + idTema.ToString(), "");
        CarregarPergunta();

        infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas";
    }

    void CarregarPergunta()
    {
        RedefinirSprites();

        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];
        respostaE.text = alternativaE[idPergunta];

        // Verificar se a questão foi acertada anteriormente
        if (PlayerPrefs.GetInt("acertou" + idTema.ToString() + idPergunta.ToString(), 0) == 1)
        {
            AlterarSpriteCorreto();
        }

        // Verificar se as alternativas foram erradas anteriormente
        AlterarSpritesIncorretos();
    }

    void AlterarSpriteCorreto()
    {
        string correta = corretas[idPergunta];
        if (alternativaA[idPergunta] == correta)
        {
            buttonA.image.sprite = spriteCorreto;
        }
        else if (alternativaB[idPergunta] == correta)
        {
            buttonB.image.sprite = spriteCorreto;
        }
        else if (alternativaC[idPergunta] == correta)
        {
            buttonC.image.sprite = spriteCorreto;
        }
        else if (alternativaD[idPergunta] == correta)
        {
            buttonD.image.sprite = spriteCorreto;
        }
        else if (alternativaE[idPergunta] == correta)
        {
            buttonE.image.sprite = spriteCorreto;
        }
    }

    void AlterarSpritesIncorretos()
    {
        if (PlayerPrefs.GetInt("errou" + idTema.ToString() + idPergunta.ToString() + "A", 0) == 1)
        {
            buttonA.image.sprite = spriteIncorreto;
        }
        if (PlayerPrefs.GetInt("errou" + idTema.ToString() + idPergunta.ToString() + "B", 0) == 1)
        {
            buttonB.image.sprite = spriteIncorreto;
        }
        if (PlayerPrefs.GetInt("errou" + idTema.ToString() + idPergunta.ToString() + "C", 0) == 1)
        {
            buttonC.image.sprite = spriteIncorreto;
        }
        if (PlayerPrefs.GetInt("errou" + idTema.ToString() + idPergunta.ToString() + "D", 0) == 1)
        {
            buttonD.image.sprite = spriteIncorreto;
        }
        if (PlayerPrefs.GetInt("errou" + idTema.ToString() + idPergunta.ToString() + "E", 0) == 1)
        {
            buttonE.image.sprite = spriteIncorreto;
        }
    }

    public void resposta(string alternativa)
    {
        bool acertou = false;

        switch (alternativa)
        {
            case "A":
                if (alternativaA[idPergunta] == corretas[idPergunta])
                {
                    acertos++;
                    acertou = true;
                    buttonA.image.sprite = spriteCorreto;
                }
                else
                {
                    buttonA.image.sprite = spriteIncorreto;
                    PlayerPrefs.SetInt("errou" + idTema.ToString() + idPergunta.ToString() + "A", 1);
                }
                break;

            case "B":
                if (alternativaB[idPergunta] == corretas[idPergunta])
                {
                    acertos++;
                    acertou = true;
                    buttonB.image.sprite = spriteCorreto;
                }
                else
                {
                    buttonB.image.sprite = spriteIncorreto;
                    PlayerPrefs.SetInt("errou" + idTema.ToString() + idPergunta.ToString() + "B", 1);
                }
                break;

            case "C":
                if (alternativaC[idPergunta] == corretas[idPergunta])
                {
                    acertos++;
                    acertou = true;
                    buttonC.image.sprite = spriteCorreto;
                }
                else
                {
                    buttonC.image.sprite = spriteIncorreto;
                    PlayerPrefs.SetInt("errou" + idTema.ToString() + idPergunta.ToString() + "C", 1);
                }
                break;

            case "D":
                if (alternativaD[idPergunta] == corretas[idPergunta])
                {
                    acertos++;
                    acertou = true;
                    buttonD.image.sprite = spriteCorreto;
                }
                else
                {
                    buttonD.image.sprite = spriteIncorreto;
                    PlayerPrefs.SetInt("errou" + idTema.ToString() + idPergunta.ToString() + "D", 1);
                }
                break;

            case "E":
                if (alternativaE[idPergunta] == corretas[idPergunta])
                {
                    acertos++;
                    acertou = true;
                    buttonE.image.sprite = spriteCorreto;
                }
                else
                {
                    buttonE.image.sprite = spriteIncorreto;
                    PlayerPrefs.SetInt("errou" + idTema.ToString() + idPergunta.ToString() + "E", 1);
                }
                break;
        }

        if (acertou)
        {
            PlayerPrefs.SetInt("acertou" + idTema.ToString() + idPergunta.ToString(), 1);
            questoesCorretas.Add(idPergunta + 1); // Armazenando o índice +1 para ficar mais intuitivo ao usuário
            PlayerPrefs.SetString("questoesCorretas" + idTema.ToString(), string.Join(",", questoesCorretas)); // Salvando a lista em PlayerPrefs
            Debug.Log("Questão correta adicionada: " + (idPergunta + 1));
        }

        proximaPergunta();
    }

    void proximaPergunta()
    {
        idPergunta++;

        if (idPergunta <= (questoes - 1))
        {
            CarregarPergunta();

            infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas";
        }
        else
        {
            media = 10 * (acertos / questoes);
            notaFinal = Mathf.RoundToInt(media);

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);

            SceneManager.LoadScene("notaFinal");
        }
    }

    void RedefinirSprites()
    {
        buttonA.image.sprite = spritePadrao;
        buttonB.image.sprite = spritePadrao;
        buttonC.image.sprite = spritePadrao;
        buttonD.image.sprite = spritePadrao;
        buttonE.image.sprite = spritePadrao;
    }
}