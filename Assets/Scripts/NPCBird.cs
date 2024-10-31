using UnityEngine;

public class NPCBird : MonoBehaviour
{
    GameObject cloud;
    float Speed = 1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Skapar ett objekt som är länkat till molnets spelobjekt
        cloud = GameObject.Find("cloud");
    }

    // Update is called once per frame
    void Update()
    {
        //FINNS TVÅ ALTERNATIV ATT FÅ FÅGELN ATT RÖRA SEJ MOT MOLNET

        //ALTERNATIV 1:
        //-------------
        //Skapar en vektor som går från fågeln till molnet genom att subrathera
        //molnets positionsvektor med fågelns positionsvektor
        Vector2 Direction = cloud.transform.position - transform.position;

        //Normaliserar Direction-vektorn (längden blir nu 1, men riktningen samma som tidigare)
        Direction.Normalize();

        //Skapar en ny vektor som definierar riktningen och hastigheten från blåa fågeln till
        //molnet. Velocity-vektorn blir den normaliserade vektorn multiplicerat med en skalär
        //för speed/hastighet
        Vector2 Velocity = Direction * Speed;

        //Till slut adderar vi Velocit vektorn med blåa fågenlns positionsvektor för varje frame för att få den
        //att röra sej mot molnet. Vi multiplicerar med time.deltaTime för att skala ner hastigheten att motsvara
        //enhter per sekunder i stället för enheter per frame
        transform.Translate(Velocity * Time.deltaTime);

        //ALTERNATIV 2:
        //-------------
        //Åstadkommer samma som i alternativ 1 fast med 1 funktionsanrop
        //transform.position = Vector2.MoveTowards(transform.position, cloud.transform.position, Speed * Time.deltaTime);
    }
}
