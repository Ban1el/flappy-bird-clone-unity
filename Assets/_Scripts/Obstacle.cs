using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D top_obs;
    private Collider2D bottom_obs;
    private BoxCollider2D entry;
    [SerializeField] private float speed = 5f;
    private Vector2 top_bound;
    private Vector2 bottom_bound;
    private float distance;
    private bool movement = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        top_obs = transform.GetChild(0).GetComponent<Collider2D>();
        bottom_obs = transform.GetChild(1).GetComponent<Collider2D>();
        entry = transform.GetChild(2).GetComponent<BoxCollider2D>();

        //Ignore ground collision
        //3 = obstacle 6 = ground
        Physics2D.IgnoreLayerCollision(3, 6);
    }

    private void FixedUpdate()
    {
        if (movement)
        {
            SetEntryColliderSize();
            MoveObstacle();
        }
    }

    private void MoveObstacle()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    private void SetEntryColliderSize()
    {
        top_bound = new Vector2(top_obs.transform.position.x, top_obs.bounds.min.y);
        bottom_bound = new Vector2(bottom_obs.transform.position.x, bottom_obs.bounds.max.y);
        distance = Vector2.Distance(top_bound, bottom_bound);
        entry.size = new Vector2(top_obs.bounds.size.x, distance);
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
        movement = false;
    }

    private void OnEnable()
    {
        Actions.OnHit += StopMovement;
    }

    private void OnDisable()
    {
        Actions.OnHit -= StopMovement;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (entry != null)
        {
            //Show entry colllider
            Gizmos.DrawWireCube(entry.transform.position, entry.size);
        }
    }
}

