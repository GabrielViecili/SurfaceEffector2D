using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float destroyAtX = -15f;

    void Update()
    {
        if (GameManager.instance == null) return;

        float currentSpeed = GameManager.instance.groundEffector.speed;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (transform.position.x < destroyAtX)
            Destroy(gameObject);
    }
}

