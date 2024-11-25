using UnityEngine;

public class GravitationalForce : MonoBehaviour
{
    //Den universella proportionalitetskonstanten. 
    //Definieras via Unity-editorn i inspektorn. Här behöver vi inte sätta den räta konstatenten
    //eftersom då går allt väldigt långsamt (låg acceleration). Ju lägre värde desto
    //fortare accerleras månen
    public float G; 

    Rigidbody2D EarthPhysics;
    Rigidbody2D MoonPhysics;
    GameObject Moon;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Hämtar en referens till jordens "fysikmotor"
        EarthPhysics = GetComponent<Rigidbody2D>();
        
        //Hämtar en referens till Ufons spelobjekt
        Moon = GameObject.Find("Ufo");
        
        //Hämtar en referens till Ufons fysikmotor via månens spelobjekt
        MoonPhysics = Moon.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Beräknr avståndet mellan Ufon och jorden för varje frame
        float r = Vector2.Distance(transform.position, Moon.transform.position);

        //Beräknar gravitationskraften enligt Newtons gravitationslag. Jordens och Ufons
        //massor är definierade i Ufons och jordens Rigidbody2D-komponenter
        float F = G*((MoonPhysics.mass * EarthPhysics.mass)/(r*r));

        //Skapr en vektor Direction för att beskriva riktningen från Ufon till jorden
        //så att vi vet åt vilket håll vi ska rikta gravitationskraften
        Vector2 Direction =  transform.position - Moon.transform.position;
        
        //Normaliserar vektorn (för att få längden till 1) och multiplicerar med gravitationskraften. 
        //Då får vi en kraft F som är riktad från Ufon till jorden. 
        Direction.Normalize();
        Vector2 Force = Direction * F;

        //Utsätter Ufon för gravitationskraften
        MoonPhysics.AddForce(Force);
    }
}
