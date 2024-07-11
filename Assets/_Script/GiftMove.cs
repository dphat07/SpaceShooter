using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMove : MonoBehaviour
{
    public float speedGift = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speedGift * Time.deltaTime);
    }
}
