
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class opcoes : MonoBehaviour
{
    public GameObject painelConfirmacao;
    public UnityEngine.UI.Button btnMenu;

    public void AbrirPainel(GameObject element)
    {
        if(element.name == "menu")
        {
            btnMenu.gameObject.SetActive(false);
        }

          element.SetActive(true);
    }

    public void FecharPainel(GameObject element)
    {
        if (element.name == "menu")
        {
            btnMenu.gameObject.SetActive(true);
        }

        element.SetActive(false);
    }

    public void resetarPontuacoes()
    {
        PlayerPrefs.DeleteAll();
        FecharPainel(painelConfirmacao);
    }

    
}
