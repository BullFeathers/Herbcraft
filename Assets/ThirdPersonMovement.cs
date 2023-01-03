using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;

    // Update is called once per frame
    void Update()
    {
        //Get wasd or arrow key input and make a new Vector3 using tat info.
        //Add "normalized" to make sure that moving diagonally doesn't double
        //speed because you're pressing 2 keys at once.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
