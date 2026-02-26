using UnityEngine;

public class Player : MonoBehaviour
{
    public LevelParser levelParser;
    public RaycastPlayer raycastPlayer;
    public Camera cameraTrack;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
            ResetGame();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lava(Clone)")
        {
            ResetGame();
        } 
        if (other.gameObject.name == "Goal(Clone)")
        {
            levelParser.GoalTouch();
        }
    }


    void ResetGame()
    {
        transform.position = new Vector3(7.5f, 2f, 0);
        cameraTrack.transform.position = new Vector3 (16.1f, 7.5f, -10f);
        raycastPlayer.ResetUI();
        levelParser.LavaTouch();
    }
}
