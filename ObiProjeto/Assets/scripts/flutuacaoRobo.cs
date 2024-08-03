using UnityEngine;

public class flutuacaoRobo : MonoBehaviour
{
    public float floatSpeed = 1f; // Velocidade da flutua��o
    public float floatHeight = 0.1f; // Altura m�xima da flutua��o

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula a posi��o Y usando a fun��o seno para criar a flutua��o
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Atualiza a posi��o do objeto
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
