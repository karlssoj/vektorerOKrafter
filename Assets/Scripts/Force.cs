using Unity.VisualScripting;
using UnityEngine;

public class Force : MonoBehaviour
{
    public Vector2 PushForce;

    public Vector2 JumpForce;

    Vector2 Velocity;

    Rigidbody2D PhysicsEngine;

    bool OnGround = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        //Hämtar en referens till spelobjektets Rigidbody2D-komponent
        PhysicsEngine = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Utsätter bilen för en kontinuerlig "push-kraft" rakt till höger
        PhysicsEngine.AddForce(PushForce);

        if(Input.GetKeyDown(KeyCode.Space) == true && OnGround == true)
        {
            //Utsätter bilen för en impulskraft rakt uppåt. 
            //(kraften multipliceras inte med time.deltatime)
            PhysicsEngine.AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }

    //Anropas av spelmotorn när i detta fall bilens collider kör in i ett
    //annat spelobjekts collid
    private void OnCollisionEnter2D(Collision2D c)
    {
        //if-satsen blir true om spelobjektet som hänger ihop med den collider
        //vi krockat med heter "landscape"
        if(c.gameObject.name == "landscape")
        {
                OnGround = true;
        }
    }


    //Anropas av spelmotorn när i detta fall bilens collider lämnar ett annat
    //spelobjekt collider
    private void OnCollisionExit2D(Collision2D c)
    {
        if(c.gameObject.name == "landscape")
        {
                OnGround = false;
        }     
    }

    //Anropas av spelmotorn när i detta fall bilens collider kör in i ett
    //annat spelobjekts collider som är definierad som en trigger (isTrigger 
    //förkruxat under BoxCollider2D-kompoenenten)
    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("I MÅL!!!!!");
    }
}

