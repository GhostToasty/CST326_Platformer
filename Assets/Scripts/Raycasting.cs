// using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Raycasting : MonoBehaviour
{
    public Camera rayCamera;
    public GameObject brick;
    public GameObject question;
    public TextMeshProUGUI coinText;
    private int coinCount = 00;
    public TextMeshProUGUI pointText;
    private int pointCount = 0;
    public LevelParser levelParser;
    // public GameObject coin;
    

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
                // Debug.Log("click");

        
                if (clickHit.collider != null)
                {
                    Debug.Log ("hit: " + clickHit.collider.name);
                    
                    if (clickHit.collider.name == "Brick(Clone)")
                    {
                        levelParser.DestroyBrick(clickHit.transform);
                        PointCount();
                        // Debug.Log("collide brick");
                    }   

                    if (clickHit.collider.name == "Question(Clone)")
                    {
                        // levelParser.CoinAnimation(clickHit.transform, coin);
                        PointCount();
                        coinCount += 1;
                        if (coinCount < 10)
                        {
                            string coin = $"x0{coinCount}";
                            coinText.text = coin;
                        }   
                        else
                        {
                            string coin = $"x{coinCount}";
                            coinText.text = coin;
                        }
                        // Debug.Log("collide question");
                    }
                }
                    
                
                  
            }
                            
        }
    }

    void PointCount()
    {
        pointCount += 100;
        if (pointCount < 1000)
        {
            string point = $"Mario\n000{pointCount}";
            pointText.text = point;
        }
        else if (pointCount < 10000)
        {
            string point = $"Mario\n00{pointCount}";
            pointText.text = point;
        }
        else if (pointCount < 100000)
        {
            string point = $"Mario\n0{pointCount}";
            pointText.text = point;
        }
        else
        {
            string point = $"Mario\n{pointCount}";
            pointText.text = point;
        }   
    }

    public void ResetUI()
    {
        coinCount = 0;
        pointCount = 0;

        string point = $"Mario\n00000{pointCount}";
        pointText.text = point;

        string coin = $"x0{coinCount}";
        coinText.text = coin;
    }

}
