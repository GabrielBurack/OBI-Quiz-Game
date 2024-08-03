using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temaInfo : MonoBehaviour
{
    public int idTema;
    private int notaFinal;
    public GameObject[] estrela;

    void Start()
    {
        for(int i=0; i<3; i++)
        {
            estrela[i].SetActive(false);
        }

        int nota = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
