using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static System.Net.WebRequestMethods;

public class OpenWebPage : MonoBehaviour, IPointerClickHandler
{
    public string url = "https://olimpiada.ic.unicamp.br/pratique/";

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(url);
    }
}
