using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo2 : MonoBehaviour
{
    private Animator anim;
    public PlayerController playerController2;
    [SerializeField]
    private Transform posicaoDetiro2;
    [SerializeField]
    private GameObject tiroprefab2;
    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && playerController2.disparo2)
        {
            Atira();
        }
    }
    private void Atira()
    {
        int X2 = 0;
        if (playerController2.viradoDireita)
        {
            X2 = 1;
        }
        else
        {
            X2 = -1;
        }
        GameObject tiro = Instantiate(tiroprefab2, transform.position, posicaoDetiro2.rotation);
        Vector3 direita = new Vector3(X2, 1, 1);
        tiro.transform.localScale = direita;
        tiro.GetComponent<velocidadedisparo>().Flip(X2);
    }
}
