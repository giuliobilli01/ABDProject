using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{   
    public Transform MeshTransform; // parte grafica del character
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5f;
    
    [SerializeField] private Vector2 inputVector;

    private Vector3 lastMoveDirection;
    void Start()
    {
        
    }

    // in questo modo non si usa la fisica e quindi le collisioni non ci sono
    void Update()
    {
      Move();

    }

    private void Move() {
        
       
        float moveDistance = moveSpeed * Time.deltaTime; // calcoliamo la distanza in base alla velocità

        inputVector = GetInputVector();

        Vector3 moveDir = new Vector3(inputVector.y, 0, inputVector.x);
        
        if(moveDir != lastMoveDirection) {
            // in questo modo rimane ruotato
            lastMoveDirection = moveDir;
        }

        transform.position += moveDir * moveDistance;

        // lo rouotiamo verso la move dir
        MeshTransform.forward = Vector3.Slerp(MeshTransform.forward, moveDir, Time.deltaTime * rotationSpeed);
        
    }
    private Vector2 GetInputVector() {
     
        // Set moveDirection to Zero
        Vector2 input = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            // Player should move forward
            input.x += 1;
        }

        if (Input.GetKey(KeyCode.S)) {
            // Player should move backword
            input.x += -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            // Player should move Left
            input.y += -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            // Player should move Right
            input.y += 1;
        }

        return input;
    }

    // public void Rotate(Transform meshTransform) {
    //     meshTransform.LookAt(lastMoveDirection + transform.position, transform.up);

    // }
}
