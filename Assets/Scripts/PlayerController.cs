using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private Rigidbody2D rb2d;
    public int armaatual = 0;
	[HideInInspector] public bool disparo1 = false;
	public Transform posPe;
	[HideInInspector] public bool tocaChao = false;
	public float Velocidade;
	public float ForcaPulo = 1000f;
	[HideInInspector] public bool viradoDireita = true;
	[HideInInspector] public bool jump;
	public Image vida;
	private MensagemControle MC;

	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

		GameObject mensagemControleObject = GameObject.FindWithTag ("MensagemControle");
		if (mensagemControleObject != null) {
			MC = mensagemControleObject.GetComponent<MensagemControle> ();
		}
	}

	// Update is called once per frame
	void Update()
	{
		//Implementar Pulo Aqui!
		tocaChao= Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("chao"));

        if (Input.GetKeyDown("space") && tocaChao) 
		{
			jump = true; 
		}
	}

	void FixedUpdate()
	{
		if(Input.GetKeyDown("1"))
        {
			armaatual = 1;
			disparo1 = true;
		}
		if (Input.GetKeyDown("2"))
		{
			armaatual = 2;
			disparo1 = false;
		}
		if (Input.GetKeyDown("0"))
		{
			armaatual = 0;
			disparo1 = false;
		}

		float translationY = 0;
		float translationX = Input.GetAxis ("Horizontal") * Velocidade;
		transform.Translate (translationX, translationY, 0);
		transform.Rotate (0, 0, 0);
		if (translationX != 0 && tocaChao)
		{
			anim.SetInteger("corridaarma", armaatual);
		}
		else
		{
			anim.SetInteger("corridaarma", 3);
		}
		//Programar o pulo Aqui! 
		if (jump)
        {
			anim.SetTrigger("pula");
			rb2d.AddForce(new Vector2(0f, 1000f));
			jump = false;
        }
;
        if (translationX > 0 && !viradoDireita) {
			Flip ();
		} else if (translationX < 0 && viradoDireita) {
			Flip();
		}

	}
	void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}

	public void SubtraiVida()
	{
		vida.fillAmount-=0.1f;
		if (vida.fillAmount <= 0) {
			MC.GameOver();
			Destroy(gameObject);
		}
	}	
}
