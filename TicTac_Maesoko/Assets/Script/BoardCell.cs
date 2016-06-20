using UnityEngine;
using System.Collections;

public class BoardCell : MonoBehaviour {

	public Sprite player1Mark;
	public Sprite player2Mark;

	private BoardManager boardManager;
	private MarkHolder markHolder;

	// Use this for initialization
	void Start () {
		boardManager = gameObject.GetComponentInParent<BoardManager> ();
		markHolder = gameObject.GetComponentInChildren<MarkHolder> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//オブジェクト上で左クリックされたら呼び出される
	void OnMouseDown() {
		//既に記号が配置されていたら、反応させない
		if (markHolder.Mark != null) return;

		//クリックされたパネルの記号を配置する
		DeployMark(this.boardManager.IsPlayer1Turn);

		//ターンフラグを反転させる
		this.boardManager.InvertTurn ();
	}

	/// <summary>
	/// Deploys the mark.
	/// </summary>
	/// <param name="isPlayer1Turn">If set to <c>true</c> is player1 turn.</param>
	private void DeployMark(bool isPlayer1Turn) {
		this.markHolder.Mark = isPlayer1Turn ? this.player1Mark : this.player2Mark;
	}
}
