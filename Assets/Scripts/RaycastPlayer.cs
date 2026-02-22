using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class RaycastPlayer : MonoBehaviour
{
    // public Rigidbody player;
    public Rigidbody player;
    public GameObject brick;
    public GameObject question;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;
    public TextMeshProUGUI pointText;
    private int pointCount = 0;
    public LevelParser levelParser;

    

    // Update is called once per frame
    void Update()
    {
        // Vector3 origin = player.transform.position;
        // Vector3 direction = player.transform.forward;
        RaycastHit playerHit;
        // Ray playerRay = new Ray(player.position + Vector3.up * 0.01f, Vector3.up);
        Ray playerRay = new Ray(player.transform.position, Vector3.up);
        Debug.Log(player.transform.position);

        Debug.DrawLine(player.transform.position, Vector3.up, Color.green);

        if (Physics.Raycast(playerRay, out playerHit))
        {
            Debug.DrawLine(playerRay.origin, playerHit.point, Color.blue);

            // Debug.DrawLine(playerRay.origin, playerHit.point, Color.red);
    
            if (playerHit.collider != null)
            {
                Debug.Log ("hit: " + playerHit.collider.name);
                
                if (playerHit.collider.name == "Brick(Clone)")
                {
                    levelParser.DestroyBrick(playerHit.transform);
                    PointCount();
                    // Debug.Log("collide brick");
                }   

                if (playerHit.collider.name == "Question(Clone)")
                {
                    // levelParser.CoinAnimation(playerHit.transform, coin);
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


    void ResetUI()
    {
        
    }


}
