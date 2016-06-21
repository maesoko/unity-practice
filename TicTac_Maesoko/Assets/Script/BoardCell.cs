using UnityEngine;
using System.Collections;

public class BoardCell : MonoBehaviour {

	public Sprite player1Mark;
	public Sprite player2Mark;

	private BoardManager boardManager;
	private MarkHolder markHolder;
	private CellStates cellState;

	public CellStates CellState
	{
		get { return this.cellState; }
		set { this.cellState = value; }
	}

	public enum CellStates
	{
		empty,
		O,
		X
	}

	// Use this for initialization
	void Start ()
	{
		boardManager = gameObject.GetComponentInParent<BoardManager> ();
		markHolder = gameObject.GetComponentInChildren<MarkHolder> ();
		cellState = CellStates.empty;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	//オブジェクト上で左クリックされたら呼び出される
	void OnMouseDown()
	{
		//ゲーム開始前か、既に記号が配置されていたら、パネルを反応させない
		if (!boardManager.IsGameRunning || markHolder.Mark != null) return;

		//クリックされたパネルの記号を配置する
		DeployMark(this.boardManager.IsPlayer1Turn);

		//勝敗の判定
		boardManager.Judge (CellState);

		//ターンフラグを反転させる
		this.boardManager.InvertTurn ();
	}

	/// <summary>
	/// Deploys the mark.
	/// </summary>
	/// <param name="isPlayer1Turn">If set to <c>true</c> is player1 turn.</param>
	private void DeployMark(bool isPlayer1Turn)
	{
		if (isPlayer1Turn)
		{
			this.markHolder.Mark = this.player1Mark;
			this.CellState = CellStates.O;
		}
		else
		{
			this.markHolder.Mark = this.player2Mark;
			this.CellState = CellStates.X;
		}
	}
}
