using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class RaycastPlayer : MonoBehaviour
{
    
    public GameObject brick;
    public GameObject question;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;
    public TextMeshProUGUI pointText;
    private int pointCount = 0;
    public LevelParser levelParser;
    public Rigidbody player;
    public CharacterDriver charDrive;
    private bool gotCoin = false;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit playerHit;
        Ray playerRay = new Ray(player.transform.position + Vector3.up * 0.01f, Vector3.up);

        Debug.DrawLine(playerRay.origin, playerRay.origin + playerRay.direction * 2f, Color.green);
        // Debug.Log(coinCount);

        if (Physics.Raycast(playerRay, out playerHit, 2f))
        {
            // Debug.DrawLine(playerRay.origin, playerHit.point, Color.blue);
            // Debug.Log ("hit: " + playerHit.collider.name);
            
            if (playerHit.collider != null && playerHit.collider.name != "Mario")
            {
                // Debug.Log ("hit: " + playerHit.collider.name);
                
                if (playerHit.collider.name == "Brick(Clone)")
                {
                    if (charDrive.CheckGrounded() == false)
                    {
                        levelParser.DestroyBrick(playerHit.transform);
                        PointCount();
                    }
                    
                    // Debug.Log("collide brick");
                }   

                if (playerHit.collider.name == "Question(Clone)")
                {
                    if (charDrive.CheckGrounded() == false && gotCoin == false)
                    {
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
                        gotCoin = true;
                    }
                    // Debug.Log("collide question");
                }

            }
                            
        }

        // Debug.Log(charDrive.CheckGrounded());
        if (charDrive.CheckGrounded() == true)
            gotCoin = false;

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
