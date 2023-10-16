using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlatfrom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player(Clone)" || collision.gameObject.name == "Player 2(Clone)" || collision.gameObject.name == "Player 3(Clone)")
        {
           collision.gameObject.transform.SetParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player(Clone)" || collision.gameObject.name == "Player 2(Clone)" || collision.gameObject.name == "Player 3(Clone)")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
