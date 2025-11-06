using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float loseHeight = 5f;
    public bool IsGameOver { get; private set; } = false;

    public void CheckLoseCondition()
    {
        if (IsGameOver) return;

        int count = 0;
        GameObject[] tetrominos = GameObject.FindGameObjectsWithTag("Tetromino");

        foreach (GameObject t in tetrominos)
        {
            if (t.transform.position.y >= loseHeight)
            {
                count++;
            }
        }

        if (count >= 5)
        {
            IsGameOver = true;
            Debug.Log("Game Over");
            SceneManager.LoadScene("LoseScene");
        }
    }
}
