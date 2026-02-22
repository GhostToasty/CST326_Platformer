using UnityEngine;

public class Player : MonoBehaviour
{
    public LevelParser levelParser;
    public Raycasting raycasting;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lava(Clone)")
        {
            levelParser.LavaTouch();
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
        raycasting.ResetUI();
    }
}
