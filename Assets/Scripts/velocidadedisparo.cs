using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class velocidadedisparo : MonoBehaviour
{
    private float velocidade = 500;
    private int x = 1;
    private Animator anim;
    public Disparo disparo;
    float tempo = 2.0f;
    // Start is called before the first frame update
    void Update()
    {
        tempo -= Time.deltaTime;
        if (tempo <= 0.0f)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        velocidade *= x;
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * velocidade);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        tempo += 0.5f;
        tempo -= 1.3f;
        velocidade *= -1;
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * velocidade);
        anim.SetTrigger("comeco");
    }
    public void Flip(int _x)
    {
         x = _x;
    }   
}
