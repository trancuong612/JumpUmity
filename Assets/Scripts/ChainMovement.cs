using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _ChainMovement();
    }

    private void _ChainMovement()
    {
        Vector3 Temp = transform.position;
        Temp.x -= speed *Time.deltaTime;
        transform.position = Temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
        }
    }
}
