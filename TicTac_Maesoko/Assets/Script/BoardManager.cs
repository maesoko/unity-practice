using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public BoardCell[] boardCells;
	private MarkHolder[] markHolders;
	private bool isPlayer1Turn;
	private bool isGameRunning;

	public const int EMPTY_CELL = 0;
	public const int O_CELL = 1;
	public const int X_CELL = 2;
	public const int BOARD_WIDTH = 3;
	public const int BOARD_HEIGHT = 3;

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

	public int[,] GetBoardAsInts()
	{
		int[,] cells = new int[BOARD_HEIGHT, BOARD_WIDTH];
		int cellCount = 0;
		int height = cells.GetLength (0);
		int width = cells.GetLength (1);

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++) 
			{
				cells [i, j] = CellStateToInt (boardCells [cellCount++].CellState);
			}
		}

		return cells;
	}

	private int CellStateToInt(BoardCell.CellStates state)
	{
		switch (state) 
		{
		case BoardCell.CellStates.empty:
			return EMPTY_CELL;
		case BoardCell.CellStates.O:
			return O_CELL;
		case BoardCell.CellStates.X:
			return X_CELL;
		default:
			return -1;
		}
	}

}