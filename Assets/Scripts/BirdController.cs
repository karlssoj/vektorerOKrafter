using UnityEngine;

public class BirdController : MonoBehaviour
{
    Vector2 Speed;
    GameObject cloud;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //Initialiserar vektorn Speed (default är 0 i x-led och 0  i y-led )
       Speed = new Vector2(0, 0);
       cloud = GameObject.Find("cloud");
    }

    // Update is called once per frame
    void Update()
    {
        //För varje frame, addera vektorn Speed till positionsvektorn
        transform.Translate(Speed * Time.deltaTime);
        KeyboardControl();  

        Debug.Log("Avstånd till molnet: "  + Vector2.Distance(transform.position, cloud.transform.position));
    }

    void KeyboardControl()
    {
        if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            Speed.x = 1;
        }

        else if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            Speed.x = -1;
        }

        else
        {
            Speed.x = 0;
            Speed.y = 0;   
        }
    }
}
