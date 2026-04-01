using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private GameObject ball;

    void Start()
    {
        // Mencari bola di awal
        ball = GameObject.Find("Ball");
    }

    void Update()
    {
        if (ball == null) return;

        // Tentukan posisi target (Y bola)
        float targetY = ball.transform.position.y;

        // Gerakkan posisi paddle P2 perlahan menuju targetY
        float newY = Mathf.MoveTowards(transform.position.y, targetY, speed * Time.deltaTime);

        // Terapkan posisi baru (X tetap, Y berubah)
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}