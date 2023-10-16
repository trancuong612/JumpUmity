using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource DieEffect;
    
    void Start()
    {
        animator= GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            DieEffect.Play();
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Die");
    }
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
