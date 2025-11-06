using UnityEngine;

public class Tetris : MonoBehaviour
{
    private float fallSpeed = 3f;
    private float moveSpeed = 5f;
    private bool isLocked = false;
    private Rigidbody rigidbodyT;
    private Spawner spawner;
    private GameManager gameManager;

    public static Tetris activePiece;

    private void Start()
    {
        rigidbodyT = GetComponent<Rigidbody>();
        spawner = Object.FindFirstObjectByType<Spawner>();
        gameManager = Object.FindFirstObjectByType<GameManager>();
        activePiece = this;
    }

    private void Update()
    {
        if (activePiece != this || isLocked) return;

        HandleMovement();
        FallPiece();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    private void FallPiece()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLocked) return;

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.GetComponent<Tetris>() != null)
        {
            isLocked = true;
            rigidbodyT.isKinematic = true;

            // Avisa al spawner para generar el siguiente
            if (spawner != null)
                spawner.SpawnNextTetromino();

            // condición de derrota
            if (gameManager != null)
                gameManager.CheckLoseCondition();
        }
    }
}
