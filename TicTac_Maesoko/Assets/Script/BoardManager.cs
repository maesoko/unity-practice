using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public const int EMPTY_CELL = 0;
	public const int O_CELL = 1;
	public const int X_CELL = 2;
	public const int BOARD_WIDTH = 3;
	public const int BOARD_HEIGHT = 3;

	private bool isPlayer1Turn;
	private bool isGameRunning;
	private JudgeManager judgeMgr;
	
	public BoardCell[] boardCells;
	public GameObject player1Win;
	public GameObject player2Win;
	public GameObject draw;
	public MarkChanger markChanger;

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

	public void InvertTurn()
	{
		IsPlayer1Turn = !IsPlayer1Turn;
		markChanger.ChangeTurnMark (IsPlayer1Turn);
	}

	void Start()
	{
		this.judgeMgr = new JudgeManager ();
	}

	public void StartGame()
	{
		//ゲーム結果をクリアする
		ClearResult();

		//ボード上の全ての記号をクリア
		ClearBoard ();

		//ターンフラグを元に戻す
		IsPlayer1Turn = true;

		//ゲーム開始フラグを立てる
		IsGameRunning = true;
	}

	public void FinishGame()
	{
		IsGameRunning = false;
	}

	private void ClearResult()
	{
		this.player1Win.SetActive (false);
		this.player2Win.SetActive (false);
		this.draw.SetActive (false);
	}

	private void ClearBoard()
	{
		foreach (BoardCell cell in boardCells)
		{
			cell.Initialize ();
		}
	}

	public int[][] GetBoardAsInts()
	{
		int[][] board = new int[BOARD_HEIGHT][];
		int cellCount = 0;

		for (int i = 0; i < board.Length; i++)
		{
			board[i] = new int[BOARD_WIDTH];
			for (int j = 0; j < board[i].Length; j++) 
			{
				board [i][j] = CellStateToInt(boardCells [cellCount++].CellState);
			}
		}

		return board;
	}

	public void Judge(CellStates target)
	{
		int[][] board = GetBoardAsInts ();

		if (judgeMgr.Judge(target, board))
		{
			ShowWinner ();
		}
		else if (judgeMgr.IsDraw(board))
		{
			showDraw ();
		}
	}

	private void ShowWinner()
	{
		if (IsPlayer1Turn)
		{
			player1Win.SetActive (true);
		}
		else
		{
			player2Win.SetActive (true);
		}

		FinishGame ();
	}

	private void showDraw()
	{
		draw.SetActive (true);
		FinishGame ();
	}

	public static int CellStateToInt(CellStates state)
	{
		switch (state) 
		{
		case CellStates.empty:
			return EMPTY_CELL;
		case CellStates.O:
			return O_CELL;
		case CellStates.X:
			return X_CELL;
		default:
			return -1;
		}
	}

}