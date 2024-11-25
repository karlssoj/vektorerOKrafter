using UnityEngine;

public class UfoController : MonoBehaviour
{
    // Referens till Rigidbody2D-komponenten för att hantera fysik
    Rigidbody2D phy;

    // Variabel för att lagra kraften som ska appliceras på UFO:t
    Vector2 UfoForce;

    // Variabel för att bestämma kraftens styrka
    public float Power;

    // Start anropas en gång innan första körningen av Update när MonoBehaviour skapas
    void Start()
    {
        // Initierar UfoForce med en vektor av värdet (0, 0)
        UfoForce = new Vector2(0, 0);
        // Hämtar referensen till Rigidbody2D-komponenten
        phy = GetComponent<Rigidbody2D>();   
    }

    // Update anropas en gång per bildruta
    void Update()
    {
        // Nollställer UfoForce i början av varje ram
        UfoForce = Vector2.zero;

        // Kollar om uppåtpilen trycks ned och sätter Y-komponenten av UfoForce
        if (Input.GetKey(KeyCode.UpArrow))
            UfoForce.y = Power;
        // Kollar om nedåtpilen trycks ned och sätter Y-komponenten av UfoForce till negativ kraft
        if (Input.GetKey(KeyCode.DownArrow))
            UfoForce.y = -Power;
        // Kollar om vänsterpilen trycks ned och sätter X-komponenten av UfoForce till negativ kraft
        if (Input.GetKey(KeyCode.LeftArrow))
            UfoForce.x = -Power;
        // Kollar om högerpilen trycks ned och sätter X-komponenten av UfoForce
        if (Input.GetKey(KeyCode.RightArrow))
            UfoForce.x = Power;

        // Applicerar kraften på UFO:t relativt dess orientering
        phy.AddRelativeForce(UfoForce);
    }
}
