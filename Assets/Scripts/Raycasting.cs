using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycasting : MonoBehaviour
{
    public Camera rayCamera;
    public GameObject brick;
    public GameObject question;
    public TextMeshProUGUI coinText;
    private int coinCount = 00;
    public LevelParser levelParser;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.value;
        RaycastHit clickHit;
        Ray clickRay = rayCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(clickRay, out clickHit))
        {
            Debug.DrawLine(clickRay.origin, clickHit.point, Color.blue);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.DrawLine(clickRay.origin, clickHit.point, Color.red);
                Debug.Log("click");

                
                if (clickHit.collider != null)
                {
                    Debug.Log ("hit: " + clickHit.collider.name);
                    
                    if (clickHit.collider.name == "Brick(Clone)")
                    {
                        // destroyBrick.destroySelf();
                        // destroyBrick.DestroyInstance();
                        levelParser.DestroyBrick(clickHit.transform);
                        Debug.Log("collide brick");
                    }   

                    if (clickHit.collider.name == "Question(Clone)")
                    {
                        coinCount += 1;
                        string coin = $"x{coinCount}";
                        coinText.text = coin;
                        Debug.Log("collide question");
                    }
                }
                    
                
                  
            }
                            
        }
    }

    // void DestroySelf()
    // {
        
    // }
}
