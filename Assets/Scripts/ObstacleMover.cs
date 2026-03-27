using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Posicao X em que o obstaculo sera destruido (fora da tela)
    public float destroyAtX = -15f;

    void Update()
    {
        if (GameManager.instance == null) return;

        // Sincroniza com a velocidade atual da esteira
        float currentSpeed = GameManager.instance.groundEffector.speed;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        // Auto-destroi ao sair da tela
        if (transform.position.x < destroyAtX)
            Destroy(gameObject);
    }
}

