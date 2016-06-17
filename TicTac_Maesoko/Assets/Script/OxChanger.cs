using UnityEngine;
using System.Collections;

public class OxChanger : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	public Sprite Ox {
		get { return this.spriteRenderer.sprite; }
		set { this.spriteRenderer.sprite = value; }
	}

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
