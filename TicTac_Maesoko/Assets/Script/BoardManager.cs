using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	private MarkHolder[] markHolders;
	private bool isPlayer1Turn;
	private bool isGameRunning;

	public BoardCell[] boardCells;

	public const int EMPTY_CELL = 0;
	public const int O_CELL = 1;
	public const int X_CELL = 2;

	public bool IsPlayer1Turn
	{
		get { return this.isPlayer1Turn; }
		set { this.isPlayer1Turn = value; }
	}

	public bool IsGameRunning
	{
		get { return this.isGameRunning; }
		set { this.isGameRunning = value; }
	}

	// Use this for initialization
	void Start ()
	{
		IsPlayer1Turn = true;
		markHolders = GetComponentsInChildren<MarkHolder> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void InvertTurn()
	{
		IsPlayer1Turn = !IsPlayer1Turn;
	}

	public void StartGame()
	{
		//ボード上の全ての記号をクリア
		ClearBoard ();

		//ターンフラグを元に戻す
		IsPlayer1Turn = true;

		//ゲーム開始フラグを立てる
		IsGameRunning = true;
	}

	private void ClearBoard()
	{
		foreach (MarkHolder markHolder in markHolders) 
		{
			markHolder.Mark = null;
		}
	}

	public int[] GetBoardAsInts()
	{
		int boardSize = boardCells.Length;
		int[] cells = new int[boardSize];

		for (int i = 0; i < boardSize; i++) 
		{
			switch (boardCells [i].CellState)
			{
			case BoardCell.CellStates.empty:
				cells [i] = EMPTY_CELL;
				break;
			case BoardCell.CellStates.O:
				cells [i] = O_CELL;
				break;
			case BoardCell.CellStates.X:
				cells [i] = X_CELL;
				break;
			}
		}

		return cells;
	}
}
