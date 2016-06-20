using UnityEngine;
using System.Collections;

public class BoardCell : MonoBehaviour {

	public Sprite spriteO;
	public Sprite spriteX;

	private BoardManager boardManager;
	private OxChanger oxChanger;

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
		//既にマルバツが配置されていたら、反応させない
		if (oxChanger.Ox != null) return;

		//クリックされたパネルのマルバツを変更する
		DeployMark(this.boardManager.IsPlayer1Turn);

		//ターンフラグを反転させる
		this.boardManager.InvertTurn ();
	}

	/// <summary>
	/// Deploys the mark.
	/// </summary>
	/// <param name="isPlayer1Turn">If set to <c>true</c> is player1 turn.</param>
	private void DeployMark(bool isPlayer1Turn) {
		this.oxChanger.Ox = isPlayer1Turn ? this.spriteO : this.spriteX;
	}
}
