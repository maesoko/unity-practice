using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	private bool isPlayer1Turn;

	public bool IsPlayer1Turn
	{
		get { return this.isPlayer1Turn; }
		set { this.isPlayer1Turn = value; }
	}

	// Use this for initialization
	void Start () {
		IsPlayer1Turn = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InvertTurn()
	{
		IsPlayer1Turn = !IsPlayer1Turn;
	}
}
