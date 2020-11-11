using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]    private float speed = 30f;
    [SerializeField]    private float turnSpeed = 5f;

    private PlayerInput playerInput;
    private float lastThrust = float.MinValue;

    public event Action<float> ThrustChanged = delegate { };

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (lastThrust != playerInput.Vertical)
            ThrustChanged(playerInput.Vertical);

        lastThrust = playerInput.Vertical;

        transform.position += Time.deltaTime * playerInput.Vertical * transform.forward * speed;
        transform.Rotate(Vector3.up * playerInput.Horizontal * turnSpeed * Time.deltaTime);
    }
}
