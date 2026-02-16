// using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; 

public class DemoLogic : MonoBehaviour
{
    public Rigidbody payload;
    public Camera rayCamera;
    public Transform parachute;
    public Transform debugSphere;
    public float parachuteDeployHeight = 3f;

    float _startingDrag;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startingDrag = payload.linearDamping;
        // StartCoroutine(LearnAboutCoroutine());
        StartCoroutine(AnimateParachuteScale(Vector3.zero, Vector3.one, 2f));
    }

    // IEnumerator LearnAboutCoroutines()
    // {
    //     Debug.Log("starting coroutine #0");
    //     yield return new WaitForSeconds(1f);
    //     Debug.Log("Waited #1");
    //     yield return new WaitForSeconds(1f);
    //     Debug.Log("Waited #2");
    // }

    // Update is called once per frame
    void Update()
    {
        //create ray from object downward by x amount
        Ray proximityRay = new Ray(payload.position + Vector3.up * 0.01f, Vector3.down);

        //test if ray hits something 
        bool intersects = Physics.Raycast(proximityRay, out RaycastHit hitInfo);
        
        //if it does, make the visual ray, OW blue
        if (intersects && hitInfo.distance < parachuteDeployHeight)
        {
            parachute.gameObject.SetActive(true);
            payload.linearDamping = 7f;
            Debug.DrawRay(proximityRay.origin, proximityRay.direction, Color.red);
        }
        else
        {
            parachute.gameObject.SetActive(false);
            payload.linearDamping = _startingDrag;
            Debug.DrawRay(proximityRay.origin, proximityRay.direction, Color.blue);
        } 

        Vector3 mousePosition = Mouse.current.position.value;
        Ray screenRay = rayCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(screenRay, out RaycastHit screenHitInfo))
        {
            Debug.DrawLine(screenRay.origin, screenHitInfo.point, Color.blueViolet);
            
            if(Mouse.current.leftButton.wasPressedThisFrame)
                debugSphere.position = screenHitInfo.point;
        }
            
    }

    IEnumerator AnimateParachuteScale(Vector3 startScale, Vector3 endScale, float duration)
    {
        //start the clock
        float timeElapsed = 0f;
        
        //loop
        while (timeElapsed < duration)
        {
            // - each frame, adjust the scale by the percentage of time elaspedtowrds the duration
            timeElapsed += Time.deltaTime;
            float percentComplete = timeElapsed / duration;
            float easedPercent = easeOutQuart(1);
            // parachute.localScale = startScale + (endScale - startScale) * percentComplete;
            parachute.localScale = Vector3.Lerp(startScale, endScale, percentComplete);
            
            yield return null;
        }
        
        //clamp the final scale to be the endScale
        parachute.localScale = endScale;
    }

    float easeOutQuart(float x)
    {
        return 1f - Mathf.Pow(1f - x, 4f);
    }
}
