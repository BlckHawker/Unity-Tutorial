using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private ObstacleManager obstacleManager;

    [SerializeField]
    private Color originalObstacleColor;

    void Update()
    {
        bool playerColliding = false;
        SpriteRenderer playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        foreach (Obstacle obstacle in obstacleManager.obstacles)
        {
            SpriteRenderer obstacleSpriteRenderer = obstacle.GetComponent<SpriteRenderer>();
            if (PlayerCollidingWithObstacle(player, obstacle))
            {
                playerColliding = true;
                obstacleSpriteRenderer.color = Color.red;
            }

            else
            {
                obstacleSpriteRenderer.color = originalObstacleColor;
            }
        }

        playerSpriteRenderer.color = playerColliding ? Color.red : Color.white;
    }

    private bool PlayerCollidingWithObstacle(Player player, Obstacle obstacle)
    {
        return CircleCollision(player.transform.position, player.radius, obstacle.transform.position, obstacle.radius);
    }

    private bool CircleCollision(Vector3 pos1, float radius1, Vector3 pos2, float radius2)
    {
        //float distance = Vector2.Distance(pos1, pos2);

        //avoids using square root
        float distanceSquared = Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2);

        return distanceSquared < Mathf.Pow(radius1 + radius2, 2);
    }
}
