using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 direction;
    private Vector2 velocity;
    [SerializeField]
    public float radius;
    [SerializeField]
    float speed;
    void Start()
    {
        direction = Vector2.zero;
        velocity = Vector2.zero;
    }

    void Update()
    {
        //verifies the direction is normalized
        direction.Normalize();

        if (direction != Vector2.zero)
        {
            //rotate the player to look in the direction they're moving
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);

            velocity = direction * Time.deltaTime * speed;
            transform.position = (Vector2)transform.position + velocity;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
