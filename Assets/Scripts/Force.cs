using UnityEngine;

public class Force : MonoBehaviour
{
    public Vector2 PushForce;

    public Vector2 JumpForce;

    Vector2 Velocity;

    Rigidbody2D PhysicsEngine;

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


        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            //Utsätter bilen för en impulskraft rakt uppåt. 
            //(kraften multipliceras inte med time.deltatime)
            PhysicsEngine.AddForce(JumpForce, ForceMode2D.Impulse);
        }

    }
}

