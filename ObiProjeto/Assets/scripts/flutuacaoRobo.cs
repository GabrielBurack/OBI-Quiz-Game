using UnityEngine;

public class flutuacaoRobo : MonoBehaviour
{
    public float floatSpeed = 1f; // Velocidade da flutuação
    public float floatHeight = 0.1f; // Altura máxima da flutuação

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula a posição Y usando a função seno para criar a flutuação
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Atualiza a posição do objeto
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
