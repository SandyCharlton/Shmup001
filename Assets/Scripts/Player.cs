using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject gunLeft, gunRight;
    public GameObject bullet;

    int bulletDelay = 0;
    public int selectBulletDelay;
    public float speed;
    public int playerHealth;

    // Camera Stuff
    public Camera playerCamera;
    bool cameraZoom = false;
    int cameraDelay = 0;
    float cameraTime = 0;
    bool cameraOn = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gunLeft = transform.Find("GunLeft").gameObject;
        gunRight = transform.Find("GunRight").gameObject;
    }

    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.transform.Translate(new Vector2(0, Input.GetAxis("Vertical") * speed));
        PlayerShoot();
        bulletDelay++;
        cameraDelay++;
        cameraTime+= 0.01f;
        CameraChange();

    }

    void LateUpdate()
    {
        //CameraChange();
    }

    public void PlayerDamage()
    {
        playerHealth--;
        if (playerHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayerShoot()
    {
        if (Input.GetKey(KeyCode.Space) && bulletDelay > selectBulletDelay)
        {
            bulletDelay = 0;
            Instantiate(bullet, gunLeft.transform.position, Quaternion.identity);
            Instantiate(bullet, gunRight.transform.position, Quaternion.identity);
        }
    }

    void CameraChange()
    {
        TurnCameraOn();
        if (cameraOn == true && cameraDelay > 100)
        {
            cameraDelay = 0;
            cameraTime = 0;
            // Debug.Log("Z is pressed and Zoom is flipped");
            Debug.Log("Camera is on");
            Debug.Log(cameraTime);
            while (cameraZoom == true && cameraTime < 1)
            {
                playerCamera.orthographicSize = Mathf.Lerp(5, 10, cameraTime);
                Debug.Log(cameraTime);
            }
            while (cameraZoom == false && cameraTime < 1)
            {
                // Debug.Log("Camera zoom == -1");
                playerCamera.orthographicSize = Mathf.Lerp(10, 5, cameraTime);
                Debug.Log(cameraTime);
            }
        }
        cameraOn = false;
        Debug.Log("Camera is Off");
        
    }

    void TurnCameraOn()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            cameraOn = true;
            cameraZoom = !cameraZoom;
        }
    }
}
