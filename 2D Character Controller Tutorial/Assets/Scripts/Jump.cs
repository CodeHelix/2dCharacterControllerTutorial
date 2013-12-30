using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
	public string jumpButton = "Fire1";
	public float jumpPower = 10.0f;
	public Animator anim;
	public bool grounded = false;
	public float minJumpDelay = 0.5f;
	public Transform groundCheck;
	private float jumpTime = 0.0f;
	private bool jumped = false;

	// Use this for initialization
	void Start ()
	{
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		jumpTime -= Time.deltaTime;
		if(jumpTime < 0)
		{
			jumpTime = 0;
		}
		if(Input.GetButtonDown(jumpButton))
		{
			jumped = true;
			grounded = false;
			anim.SetTrigger("Jump");
			rigidbody2D.AddForce(transform.up*jumpPower);
			jumpTime = minJumpDelay;
		}
		if(grounded && jumpTime <= 0 && jumped)
		{
			jumped = false;
			anim.SetTrigger("Land");
		}
	}
}
