using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour {


    public InputActionAsset actions;
    public float speed = 1f, jumpStrength = 300f;
    private InputAction xAxis, jump;
    private Rigidbody _rigidBody;
    private bool _grounded = true;
    public Vector3 spawn = new Vector3(0, 0.5f, -3);

    void Awake() {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jump = actions.FindActionMap("CubeActionsMap").FindAction("Jump");
        _rigidBody = GetComponent<Rigidbody>();
        jump.performed += ctx => OnJump(ctx);

    }

    void OnEnable() {
        actions.FindActionMap("CubeActionsMap").Enable();
    }

    void OnDisable() {
        actions.FindActionMap("CubeActionsMap").Disable();
    }

    void Update() {
        MoveX();
        AutoMove();
    }

    private void AutoMove() {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void MoveX() {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;

    }

    private void OnJump(InputAction.CallbackContext ctx) {
        Debug.Log("tried to jump");
        if (_grounded) {
            _rigidBody.AddForce(transform.up * jumpStrength);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        switch(collision.gameObject.tag) {
            case "Ground":
                _grounded = true;
                break;
            case "Finish":
                speed = 0;
                break;
        }
    }
    private void OnCollisionExit(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Ground":
                _grounded = false;
                break;
        }
    }
    public void Respawn() {
        transform.position = spawn;
        transform.rotation = Quaternion.identity;
    }
}
