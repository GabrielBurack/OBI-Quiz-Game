using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset: MonoBehaviour
{
    private Material materialAtual;
    public float velocidade;
    private float offset;

    void Start()
    {
        materialAtual = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        offset += 0.001f;

        materialAtual.SetTextureOffset("_MainTex", new Vector2(offset * velocidade, 0));
    }
}
