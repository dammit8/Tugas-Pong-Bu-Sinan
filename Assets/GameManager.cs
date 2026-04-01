using UnityEngine;
using TMPro;
using System.Collections; // PENTING: Harus ada untuk menggunakan Coroutine

public class GameManager : MonoBehaviour
{
    [Header("Skor UI")]
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private TextMeshProUGUI aiText;

    [Header("Win/Lose UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI statusText;

    private int playerScore = 0;
    private int aiScore = 0;
    private bool isGameOver = false; // Mencegah skor bertambah saat masa tunggu 5 detik

    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateUI();
    }

    public void AddScore(bool isPlayer)
    {
        // Jika sedang masa tunggu pemenang, jangan tambah skor lagi
        if (isGameOver) return;

        if (isPlayer) playerScore++;
        else aiScore++;

        UpdateUI();
        CheckWinner();
    }

    void UpdateUI()
    {
        playerText.text = playerScore.ToString();
        aiText.text = aiScore.ToString();
    }

    private void CheckWinner()
    {
        if (playerScore >= 11)
        {
            StartCoroutine(EndGameRoutine("PLAYER WINS!"));
        }
        else if (aiScore >= 11)
        {
            StartCoroutine(EndGameRoutine("COMPUTER WINS!"));
        }
    }

    // Fungsi Coroutine untuk jeda 5 detik
    IEnumerator EndGameRoutine(string message)
    {
        isGameOver = true;
        statusText.text = message;
        gameOverPanel.SetActive(true); // Memunculkan teks menang

        // Pause gameplay dengan menghentikan waktu fisik
        Time.timeScale = 0;

        // Menunggu selama 5 detik (menggunakan WaitForSecondsRealtime karena Time.timeScale sedang 0)
        yield return new WaitForSecondsRealtime(5f);

        // Selesai menunggu, reset semuanya
        ResetGame();
    }

    void ResetGame()
    {
        // 1. Jalankan waktu kembali
        Time.timeScale = 1;

        // 2. Reset angka skor
        playerScore = 0;
        aiScore = 0;
        isGameOver = false;
        UpdateUI();

        // 3. Hilangkan teks kemenangan
        gameOverPanel.SetActive(false);

        // 4. Reset posisi bola ke tengah
        Ball ball = Object.FindFirstObjectByType<Ball>();
        if (ball != null) ball.ResetPosition();

        Debug.Log("Game Restarted!");
    }
}