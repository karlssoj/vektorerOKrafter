using UnityEngine;

public class Friction : MonoBehaviour
{
    // Variabler för att definiera statisk friktion och kinetisk friktion
    public float StaticFriction; // Maximal statisk friktion
    public float KineticFriction; // Friktion under rörelse

    // Referens till objektets Rigidbody2D-komponent
    Rigidbody2D physics;

    // Vektor som håller friktionskraften
    Vector2 FrictionForce;

    // Start anropas en gång när spelet startar
    void Start()
    {
        // Hämtar Rigidbody2D-komponenten från detta GameObject
        physics = GetComponent<Rigidbody2D>();

        // Initierar friktionskraften till (0, 0)
        FrictionForce = new Vector2(0, 0);
    }

    // Metod för att applicera krafter och beräkna friktion
    public void ApplyForce(Vector2 Force)
    {
        // Beräkna den maximala statiska friktionen baserat på objektets massa
        float FMax = StaticFriction * physics.mass * 9.82f; // g = 9.82 m/s²

        // Debug-utskrift av objektets linjära hastighet
        Debug.Log(physics.linearVelocity);

        // Om den applicerade kraften är mindre än max statisk friktion
        // och objektet nästan står stilla
        if (Force.magnitude < FMax && physics.linearVelocity.magnitude < 0.1f)
        {
            // Ställ in friktionskraften så att den motverkar den applicerade kraften
            FrictionForce.x = -Force.x;

            // Stoppa objektets rörelse helt
            physics.linearVelocity = new Vector2(0, 0);
        }

        // Om objektet rör sig
        if (physics.linearVelocity.magnitude >= 0.1f)
        {
            // Beräkna friktionskraften baserat på kinetisk friktion
            FrictionForce.x = physics.mass * 9.82f * KineticFriction;

            // Om hastigheten är positiv, invertera friktionskraften
            if (physics.linearVelocity.x > 0)
                FrictionForce.x *= -1;
        }

        // Beräkna den resulterande kraften genom att lägga ihop friktionskraften och den applicerade kraften
        Vector2 ResultingForce = FrictionForce + Force;

        // Applicera den resulterande kraften på objektet
        physics.AddForce(ResultingForce);
    }
}
