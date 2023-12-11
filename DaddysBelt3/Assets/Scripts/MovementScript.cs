using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 50f; // Aseta haluttu liikkumisnopeus

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Liikkuminen
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
