using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    Obstacle obstaclePrefab;

    [SerializeField]
    Player player;

    [SerializeField]
    ObstacleManager obstacleManager;
    public void CreateCircle(InputAction.CallbackContext context)
    {
        //on want to call when click is pressed
        if (context.started || context.canceled)
        {
            return;
        }

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        
        //convert from screen to wrold view
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z;

        Obstacle obstacle = Instantiate(obstaclePrefab, mousePosition, Quaternion.identity);
        obstacleManager.obstacles.Add(obstacle);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 newDirection = context.ReadValue<Vector2>();
        player.direction = newDirection;
    }
}
