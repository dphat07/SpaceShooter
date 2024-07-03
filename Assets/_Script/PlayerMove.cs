using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 30f;
    Camera mainCamera;
    bool controlIsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
        mainCamera = Camera.main;
        //ResizeBorders();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlIsActive)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //calculating mouse position in the worldspace
                mousePosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
            }

            if (transform.position.x > 8)
            {
                transform.position = new Vector3(8, transform.position.y, transform.position.z);
            }
            if (transform.position.x <-8)
            {
                transform.position = new Vector3(-8, transform.position.y, transform.position.z);
            }
            
            if (transform.position.y > 4.2f)
            {
                transform.position = new Vector3(transform.position.x, 4.2f, transform.position.z);
            }    
            if (transform.position.y <-4.2f)
            {
                transform.position = new Vector3(transform.position.x,-4.2f, transform.position.z);
            }    
        }
        

       
    }
}
