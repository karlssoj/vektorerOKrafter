using UnityEngine;

public class NPCBird : MonoBehaviour
{
   

    GameObject[] clouds;
    float Speed = 2; 

    //Variabel ska peka på det moln som fågeln ska gå till härnäst. 
    //0 betyder första molnet i arrayen, 1 betyder andra molnet i arrayen
     int CloudIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Alla moln är taggade som clouds. I detta fall läses båda molnen in till en array
        //av spelobjekt
        clouds = GameObject.FindGameObjectsWithTag("cloud");
    }

    // Update is called once per frame
    void Update()
    {

        //OM Avståndet mellan fågeln och molnet är mindre än 0.5 ska vi uppdatera CloudIndex, dvs. i praktiken
        //byta destionationen till det andra målnet
        if(Vector2.Distance(transform.position, clouds[CloudIndex].transform.position) < 0.5f)
        {
            
            //OM cloudindex var 0 ska det nu bli 1
            if(CloudIndex == 0)
            {
                CloudIndex = 1;
            }

            //OM cloudindex var 1 ska det nu bli 0
            else
            {
                CloudIndex = 0;
            }
        }


        //FINNS TVÅ ALTERNATIV ATT FÅ FÅGELN ATT RÖRA SEJ MOT MOLNET
        //ALTERNATIV 1:
        //-------------
        //Skapar en vektor som går från fågeln till molnet genom att subrathera
        //molnets positionsvektor med fågelns positionsvektor
        Vector2 Direction = clouds[CloudIndex].transform.position - transform.position;

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
