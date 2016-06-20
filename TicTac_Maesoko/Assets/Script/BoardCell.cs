using UnityEngine;
using System.Collections;

public class BoardCell : MonoBehaviour {

	public Sprite spriteO;
	public Sprite spriteX;

	private BoardManager boardManager;
	private OxChanger oxChanger;

	//暫定的なプレイヤー判定フラグ
	public bool isPlayer = true;

	// Use this for initialization
	void Start () {
		boardManager = gameObject.GetComponentInParent<BoardManager> ();
		oxChanger = gameObject.GetComponentInChildren<OxChanger> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//オブジェクト上で左クリックされたら呼び出される
	void OnMouseDown() {
		//クリックされたパネルのマルバツを変更する
		ChangeOx(this.boardManager.IsPlayer1Turn);

		//ターンフラグを反転させる
		this.boardManager.InvertTurn ();
	}

	private void ChangeOx(bool isPlayer1Turn) {
		this.oxChanger.Ox = isPlayer1Turn ? this.spriteO : this.spriteX;
	}
}
