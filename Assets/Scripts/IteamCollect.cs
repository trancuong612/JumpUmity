using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IteamCollect : MonoBehaviour
{
    
    [SerializeField] private AudioSource CollectionEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            Manager.Number_cherry++;
            PlayerPrefs.GetInt("Number_cherry", Manager.Number_cherry);
            CollectionEffect.Play();
        }
    }
}
