using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBMap
{
    public class PlayerMovement : MonoBehaviour
    {
        //bool wasJustClicked = true;
        //bool canMove;

        Rigidbody2D rb;

        public Transform EdgeBoundary;

        Boundary playerBoundary;

        Collider2D playerCollider;

        // Start
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playerCollider = GetComponent<Collider2D>();

            playerBoundary = new Boundary(EdgeBoundary.GetChild(0).position.y,
                                            EdgeBoundary.GetChild(1).position.x,
                                            EdgeBoundary.GetChild(2).position.y,
                                            EdgeBoundary.GetChild(3).position.x);
        }

        // Update
        void Update()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position
            Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
                                                                Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up));
            rb.MovePosition(clampedMousePos);

            //if (Input.GetMouseButton(0)) // 0 for left button, 1 for right button, 2 for the middle button
            //{
            //    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position

            //    if (wasJustClicked)
            //    {
            //        wasJustClicked = false;

            //        if (playerCollider.OverlapPoint(mousePos))
            //        // 'transform' contain object's position, rotation & scale
            //        {
            //            canMove = true;
            //        }
            //        else
            //        {
            //            canMove = false;
            //        }
            //    }

            //    if (canMove)
            //    {
            //        Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
            //                                                    Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up));
            //        rb.MovePosition(clampedMousePos);
            //   }
            //}
            //else
            //{
            //    wasJustClicked = true;
            //}

        }

    }
}
