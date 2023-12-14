using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float normaaliNopeus = 4f; // Normaali liikkumisnopeus
    public float juoksuNopeus = 12f; // Nopeampi juoksu
    public float stamina = 100f;
    public float staminaVahinko = 8f; // Kuinka paljon staminaa v‰hennet‰‰n per juoksukerta
    public float staminaPalautus = 5f; // Kuinka paljon staminaa palautuu, kun ei juosta

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
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f)
        {
            currentSpeed = juoksuNopeus;
            stamina -= staminaVahinko * Time.deltaTime; // V‰henn‰ staminaa juostessa
            stamina = Mathf.Clamp(stamina, 0f, 100f); // Varo, ettei stamina mene negatiiviseksi tai yli maksimin
        }
        else
        {
            currentSpeed = normaaliNopeus;
            if (stamina < 100f)
            {
                stamina += staminaPalautus * Time.deltaTime; // Palauta staminaa hitaasti, kun ei juosta
                stamina = Mathf.Clamp(stamina, 0f, 100f); // Varo, ettei stamina ylit‰ maksimia
            }
        }
    }
}
