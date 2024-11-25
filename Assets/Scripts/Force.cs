using Unity.VisualScripting;
using UnityEngine;

public class Force : MonoBehaviour
{
    // Variabler för att definiera olika krafter
    public Vector2 PushForce; // Kraft för att skjuta objektet

    // Vektor som håller aktuell hastighet
    Vector2 Velocity;

    // Referens till Friction-komponenten
    Friction FrictionEngine;

    // Bool för att hålla reda på om objektet är på marken
    bool OnGround = false;

    // Start anropas en gång när spelet startar
    void Start()
    { 
        // Hämtar Friction-komponenten
        FrictionEngine = GetComponent<Friction>();
    }

    // Update anropas en gång per bildruta
    void Update()
    {
        // Applicera kraften med hjälp av Friction-komponenten
        FrictionEngine.ApplyForce(PushForce);
    }
}
