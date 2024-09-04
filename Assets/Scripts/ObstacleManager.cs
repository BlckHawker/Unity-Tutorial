using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<Obstacle> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<Obstacle>();
    }

    public void ClearObstacles()
    {
        foreach (Obstacle obstacle in obstacles)
        { 
            Destroy(obstacle.gameObject);
        }

        obstacles.Clear();
    }
}
