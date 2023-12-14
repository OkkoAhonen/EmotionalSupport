using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float normaaliNopeus = 10f; // Normaali liikkumisnopeus
    public float juoksuNopeus = 100f; // Nopeampi juoksu

    public float stamina = 100f;

    private Rigidbody2D rb;
    private float currentSpeed; // Nykyinen nopeus

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = normaaliNopeus; // Alustetaan nykyinen nopeus normaaliksi
    }

    void FixedUpdate()
    {
        // Liikkuminen
        float vaakaSyote = Input.GetAxis("Horizontal");
        float pystySyote = Input.GetAxis("Vertical");

        Vector2 liike = new Vector2(vaakaSyote, pystySyote) * currentSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + liike);

        // Juoksu
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            staminaDrain();

            currentSpeed = juoksuNopeus;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = normaaliNopeus;
        }
    }

    void staminaDrain()
    {
        stamina -= 1;
    }
}