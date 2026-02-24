using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currPosition = transform.position;

        if (Keyboard.current.dKey.isPressed)
            {
                if (currPosition.x < 207)
                    transform.position = new Vector3(currPosition.x + (speed * Time.deltaTime), 7.5f, -10f);
            } 
            if (Keyboard.current.aKey.isPressed)
            {
                if (currPosition.x > 16)
                    transform.position = new Vector3(currPosition.x - (speed * Time.deltaTime), 7.5f, -10f);
            }

        
    }
}
