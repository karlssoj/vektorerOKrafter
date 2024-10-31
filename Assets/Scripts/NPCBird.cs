using UnityEngine;

public class NPCBird : MonoBehaviour
{
    GameObject cloud;
    float Speed = 0.01f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cloud = GameObject.Find("cloud");
    }

    // Update is called once per frame
    void Update()
    {
        //En vektor som går från fågeln till molnet
        //Vector2 Direction = cloud.transform.position - transform.position;
        //Direction.Normalize();
        //transform.Translate(Direction * Speed);

        transform.position = Vector2.MoveTowards(transform.position, cloud.transform.position, Speed);

        

    }
}
