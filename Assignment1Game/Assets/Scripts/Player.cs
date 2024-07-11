using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyPressed;
    private float horizontalInput;
    private Rigidbody rbComponent;
    // Start is called before the first frame update
    void Start()
    {
        rbComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            jumpKeyPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate(){
        rbComponent.velocity = new Vector3(horizontalInput*2, rbComponent.velocity.y,0);
        
        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0){
            return;
        }

        if(jumpKeyPressed){
            rbComponent.AddForce(Vector3.up*5,ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.layer == 7){
            Destroy(other.gameObject);
            ScoreManager.instance.AddPoint();
        }
    }
    
    private void OnTriggerExit(Collider other){
        if(other.gameObject.layer == 8){
            transform.position = new Vector3(0, 1, 0);
            rbComponent.velocity = new Vector3(0,2,0);
        }

        
    }
}
