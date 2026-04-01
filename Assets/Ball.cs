using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float startingSpeed = 5f;
    private Vector2 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        LaunchBall();
    }

    public void LaunchBall()
    {
        // Menentukan arah random
        float x = Random.Range(0, 2) == 0 ? -1f : 1f;
        float y = Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(x, y).normalized * startingSpeed;
    }

    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = initialPosition;
        LaunchBall();
    }
}