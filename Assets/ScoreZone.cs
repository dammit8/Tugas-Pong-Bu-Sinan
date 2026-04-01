using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private bool givePointToPlayer;

    // Kita ubah ke public agar bisa kita tarik manual jika cara otomatis gagal
    public GameManager manager;

    void Start()
    {
        // Jika di Inspector masih kosong, coba cari otomatis
        if (manager == null)
        {
            manager = Object.FindFirstObjectByType<GameManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Pastikan manager TIDAK NULL sebelum memanggil fungsinya
            if (manager != null)
            {
                manager.AddScore(givePointToPlayer);
            }
            else
            {
                Debug.LogError("Manager tidak ditemukan di " + gameObject.name);
            }

            // Pastikan komponen Ball ada sebelum panggil ResetPosition
            Ball ballScript = collision.GetComponent<Ball>();
            if (ballScript != null)
            {
                ballScript.ResetPosition();
            }
        }
    }
}