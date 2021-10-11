using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rocketRigidBody;
    public GameObject laserPrefab;
    public Transform spawnPoint;
    public float shootingIntensity;
    public float laserLifespan;
    public Camera cameraRocket;
    public Camera cameraScene;
    public AudioClip laserSound;
    private AudioSource source;
    public float laserVolume = 0.5f;
    

    void Start()
    {
        //keep cursor inside game view
        Cursor.lockState = CursorLockMode.Locked;

        rocketRigidBody = GetComponent<Rigidbody>();

        //enable main camera
        cameraRocket.enabled = true;
        cameraScene.enabled = false;

        //get audio source
        source = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        #region Translationsal movement

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}

        //transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.left * vertical * turnSpeed * Time.deltaTime);

        #endregion

        #region Physics

        
        Vector3 horizontalTurnVector = new Vector3(0f, horizontal * Time.deltaTime, 0f);
        Vector3 verticalTurnVector = new Vector3(vertical * Time.deltaTime, 0f, 0f);

        //horizontal turn
        rocketRigidBody.AddRelativeTorque(horizontalTurnVector);

        //vertical turn
        rocketRigidBody.AddRelativeTorque(verticalTurnVector);

        //move forward
        if (Input.GetKey(KeyCode.W))
        {
            rocketRigidBody.AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        //move backwards
        if (Input.GetKey(KeyCode.S))
        {
            rocketRigidBody.AddRelativeForce(Vector3.back * moveSpeed * Time.deltaTime);
        }

        //move left
        if (Input.GetKey(KeyCode.A))
        {
            rocketRigidBody.AddRelativeForce(Vector3.left * moveSpeed * Time.deltaTime);
        }

        //move right
        if (Input.GetKey(KeyCode.D))
        {
            rocketRigidBody.AddRelativeForce(Vector3.right * moveSpeed * Time.deltaTime);
        }



        #endregion
        //Shoot laser on mouse click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootLaser();
        }


        //switch camera view when enter is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            cameraRocket.enabled = !cameraRocket.enabled;
            cameraScene.enabled = !cameraScene.enabled;
        }

    }

    private void ShootLaser()
    {
        //Create instance of laser at the Spawn Point
        GameObject laser = Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);

        //Give laser 'mass'
        Rigidbody laserRigidBody = laser.GetComponent<Rigidbody>();

        //move laser forward
        laserRigidBody.AddRelativeForce(Vector3.forward * shootingIntensity);

        //play shoot sound
        source.PlayOneShot(laserSound, laserVolume);

        //Destroy laser
        Destroy(laser, laserLifespan);
    }
}
