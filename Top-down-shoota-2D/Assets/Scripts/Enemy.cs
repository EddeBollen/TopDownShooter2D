using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float enemySpeed = 2f;
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * enemySpeed * Time.fixedDeltaTime);
        }
    }
}
