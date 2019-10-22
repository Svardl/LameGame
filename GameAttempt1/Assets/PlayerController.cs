using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
   
   public float speed = 5f;
   public PlayerMotor motor;
   public float sensitivity = 5f;


    public float Speed { get { return speed; } set { speed = value; } }
    void Start() {
        motor = GetComponent<PlayerMotor>();
        
    }
    void Update() {
        float XMove = Input.GetAxisRaw("Horizontal");
        float ZMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHori = transform.right * XMove;
        Vector3 moveVert = transform.forward * ZMove;

        Vector3 velocity = (moveHori + moveVert).normalized * speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f)*sensitivity;
        motor.Rotate(rotation);
        
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * sensitivity;
        motor.CameraRotate = cameraRotation;

        if (Input.GetKeyDown(KeyCode.Space)) {
            motor.Jump();
        }


    }

}
