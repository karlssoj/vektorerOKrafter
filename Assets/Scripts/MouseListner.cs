using UnityEngine;

public class MouseListner : MonoBehaviour
{
    // Update anropas en gång per frame
    void Update()
    {
        // Kontrollera om vänster musknapp trycks ned
        if(Input.GetMouseButtonDown(0) == true)
        {
            // Hämta musens koordinater i pixelvärden vid nedtryckning
            Vector2 MouseDownPixelCoordinate = Input.mousePosition;

            // Konvertera pixelkoordinaterna till Unitys världskoordinater
            Vector2 MouseDownUnityCoordinate = Camera.main.ScreenToWorldPoint(new Vector3(MouseDownPixelCoordinate.x, MouseDownPixelCoordinate.y, 0));

            // Flytta bilobjektet till den plats där musen trycktes ned
            transform.position = MouseDownUnityCoordinate;
        }

        // Kontrollera om vänster musknapp släpps
        if(Input.GetMouseButtonUp(0) == true)
        {
            // Hämta musens koordinater i pixelvärden vid knappsläpp
            Vector2 MouseUpPixelCoordinate = Input.mousePosition;

            // Konvertera pixelkoordinaterna till Unitys världskoordinater
            Vector2 MouseUpUnityCoordinate = Camera.main.ScreenToWorldPoint(new Vector3(MouseUpPixelCoordinate.x, MouseUpPixelCoordinate.y, 0));

            // Flytta bilobjektet till den plats där musen släpptes
            transform.position = MouseUpUnityCoordinate;
        }
    }
}

