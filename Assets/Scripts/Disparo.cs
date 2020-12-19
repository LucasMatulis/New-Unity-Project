using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Animator anim;
    public PlayerController playerController;
    [SerializeField]
    private Transform posicaoDetiro;
[SerializeField]
        private GameObject tiroprefab;
    // Update is called once per frame
   void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && playerController.disparo1)
        {         
            Atira();
        }
    }
    private void Atira()
    {
        int X = 0;
        if(playerController.viradoDireita)
        {
            X = 1;
        }
        else
        {
            X = -1;
        }
        GameObject tiro = Instantiate(tiroprefab, transform.position, posicaoDetiro.rotation);
        Vector3 direita = new Vector3(X, 1, 1);
        tiro.transform.localScale=direita;
        tiro.GetComponent<velocidadedisparo>().Flip(X);
    }
}
