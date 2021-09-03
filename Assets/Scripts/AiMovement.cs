using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBMap
{
    public class AiMovement : MonoBehaviour
    {
        Rigidbody2D rb;

        public Transform EdgeBoundary;

        Boundary aiBoundary;
        Transform aiTransform;

        Collider2D aiCollider;

        private float angle;
        private float speed = 0.1f;

        // Start
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            aiCollider = GetComponent<Collider2D>();
            aiTransform = GetComponent<Transform>();

            angle = Mathf.PI / 6;

            aiBoundary = new Boundary(EdgeBoundary.GetChild(0).position.y,
                                            EdgeBoundary.GetChild(1).position.x,
                                            EdgeBoundary.GetChild(2).position.y,
                                            EdgeBoundary.GetChild(3).position.x);
        }

        // Update
        void Update()
        {
            aiTransform.Translate(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle), 0.0f);

            if (aiTransform.position.x < aiBoundary.Left || aiTransform.position.x > aiBoundary.Right)
            {
                angle = Mathf.PI - angle;
                angle += Random.Range(-0.2f, 0.2f);
            }
            if (aiTransform.position.y < aiBoundary.Down || aiTransform.position.y > aiBoundary.Up)
            {
                angle = - angle;
                angle += Random.Range(-0.2f, 0.2f);
            }
        }
    }
}