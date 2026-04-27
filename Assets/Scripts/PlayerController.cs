using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float[] lanes = { -0.1f, -1.65f, -3.5f }; // 상, 중, 하
    int currentLane = 1; // 중간에서 시작

    public float moveSpeed = 5.0f;

    float minX = -6.0f;
    float maxX = 6.0f;

    void Start()
    {
        Application.targetFrameRate = 60;

        Vector3 pos = transform.position;
        pos.y = lanes[currentLane];
        transform.position = pos;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        // 좌우
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            pos.x += moveSpeed * Time.deltaTime;
        }

        // 상, 중, 하 
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (currentLane > 0)
            {
                currentLane--;
                pos.y = lanes[currentLane];
            }
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (currentLane < lanes.Length - 1)
            {
                currentLane++;
                pos.y = lanes[currentLane];
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;
    }
}