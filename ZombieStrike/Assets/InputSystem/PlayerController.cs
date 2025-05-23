using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 40;
    private Vector2 m_Move;
    private float rotateSpeed = 10;
    private Vector2 m_Rotation;
    void Update()
    {
        Move(m_Move);
        RotatePlayer(m_Rotation);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }
    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;

        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }
     public void OnRotatePlayer(InputAction.CallbackContext context)
    {
        m_Rotation = context.ReadValue<Vector2>();
    }
    private void RotatePlayer(Vector2 rotation)
    {
        if (rotation.sqrMagnitude < 0.01)
            return;
        float scaledRotationSpeed = rotateSpeed * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(0, rotation.x * scaledRotationSpeed, 0);

        transform.rotation *= deltaRotation;
    }
}
