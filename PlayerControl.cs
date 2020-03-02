using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private static LayerMask enemy;
    
    [SerializeField] private float Sensitivity = 3f;
    [SerializeField] private Transform cameraTransform = default;
    private float speed;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        speed = 0.08f;
        playerTransform = GetComponent<Transform>();       
        enemy = LayerMask.NameToLayer("Enemy"); 
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleCameraMovement();
        //CheckLifePoint();
    }

    private void HandleMovement(){
        Vector3 currentPosition = playerTransform.position;
        Vector3 deltaPosition = (
            playerTransform.right * Input.GetAxis("Horizontal")
            + playerTransform.forward * Input.GetAxis("Vertical")
            ) * speed;
        deltaPosition.y = 0f;
        playerTransform.position = currentPosition + deltaPosition;
    }

    private void HandleCameraMovement() {
        float yawn = Input.GetAxis("Mouse X") * Sensitivity;
        float pitch = -Input.GetAxis("Mouse Y") * Sensitivity;
        // pitch = Mathf.Clamp(pitch,-70f, 70f);
        playerTransform.Rotate(Vector3.up * yawn);
        cameraTransform.Rotate(Vector3.right * pitch);
    }

    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == enemy){
            Debug.Log(" in ");
            transform.position += new Vector3(1f,2f,18f);
        }
    }
    
}
