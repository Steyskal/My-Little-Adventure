using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5.0f;

    [Header("Read-only")]
    [SerializeField] private Vector2 _destination = Vector2.zero;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector2 movementDirection = _destination - (Vector2)transform.position;
        transform.position += (Vector3)movementDirection * MovementSpeed * Time.deltaTime;
    }
}
