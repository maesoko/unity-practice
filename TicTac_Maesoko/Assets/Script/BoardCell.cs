﻿using UnityEngine;
using System.Collections;

public class BoardCell : MonoBehaviour {

	public Sprite spriteO;
	public Sprite spriteX;

	private OxChanger oxChanger;

	//暫定的なプレイヤー判定フラグ
	public bool isPlayer = true;

	// Use this for initialization
	void Start () {
		oxChanger = gameObject.GetComponentInChildren<OxChanger> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//オブジェクト上で左クリックされたら呼び出される
	void OnMouseDown() {
		oxChanger.Ox = isPlayer ? spriteO : spriteX;
	}

	private void ChangeOx(bool isPlayer) {
		this.oxChanger.Ox = isPlayer ? this.spriteO : this.spriteX;
	}
}