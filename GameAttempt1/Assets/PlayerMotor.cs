using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
    private Vector3 velocity;
    public Camera cam;
    private Rigidbody rb;
    Vector3 rotation;
    Vector3 cameraRotation;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 velocity) {
        this.velocity = velocity;
    }

    public void Rotate(Vector3 rotation) {
        this.rotation = rotation;
    }
    public Vector3 CameraRotate{
        set { cameraRotation = value; }
    }

    
    private void FixedUpdate() {
        PerformMovement();
        PerformRotation();
    }
    void PerformMovement() {

        if (velocity != Vector3.zero) {
            rb.MovePosition(transform.position+ velocity *Time.fixedDeltaTime);
        
        }
    }

    void PerformRotation() {

        rb.MoveRotation(transform.rotation*Quaternion.Euler(rotation));

        if (cam != null){
            cam.transform.Rotate(-cameraRotation);
        }

    }
}
