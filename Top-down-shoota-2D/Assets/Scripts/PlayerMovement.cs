using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Vector2 screenBoundary;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 2000f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    


    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;

        if (moveInput != Vector2.zero)
        {



            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotate);
        }
        else
        {
            rb.angularVelocity = 0;
        }

        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x()))
    }
}
