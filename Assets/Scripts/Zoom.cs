using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera camera;

    public float ZoomSpeed;
    
	// Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            camera.orthographicSize-=ZoomSpeed;
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            camera.orthographicSize+=ZoomSpeed;
        }
    }
}
