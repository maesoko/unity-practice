using UnityEngine;
using System.Collections;
using System.Linq;

public class BoardManager : MonoBehaviour {

	public BoardCell[] boardCells;
	private bool isPlayer1Turn;
	private bool isGameRunning;
	public GameObject player1Win;
	public GameObject player2Win;
	public GameObject draw;

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

	public void InvertTurn()
	{
		IsPlayer1Turn = !IsPlayer1Turn;
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
		int[][] cells = new int[BOARD_HEIGHT][];
		int cellCount = 0;

		for (int i = 0; i < cells.Length; i++)
		{
			cells[i] = new int[BOARD_WIDTH];
			for (int j = 0; j < cells[i].Length; j++) 
			{
				cells [i][j] = CellStateToInt(boardCells [cellCount++].CellState);
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

	public void Judge(BoardCell.CellStates target)
	{
		int[][] board = GetBoardAsInts ();

		if (JudgeHorizon(target, board) || JudgeVertical(target, board) ||
			JudgeLeftAngle(target, board) || JudgeRightAngle(target, board))
		{
			ShowWinner ();
		}
		else if (IsDraw(board))
		{
			showDraw ();
		}
	}

	private bool JudgeHorizon(BoardCell.CellStates target, int[][] board)
	{
		for (int i = 0; i < board.Length; i++)
		{
			if (isWin (target, board [i])) return true;
		}

		return false;
	}

	private bool JudgeVertical(BoardCell.CellStates target, int[][] board)
	{
		int[] verticalAry = new int[BOARD_HEIGHT];

		for (int i = 0; i < board.Length; i++)
		{
			for (int j = 0; j < board [i].Length; j++)
			{
				verticalAry [j] = board [j] [i];
			}

			if (isWin (target, verticalAry)) return true;
		}

		return false;
	}

	private bool JudgeLeftAngle(BoardCell.CellStates target, int[][] board)
	{
		bool[,] isLeftAngleCells = 
		{
			{true, false, false},
			{false, true, false},
			{false, false, true}
		};
		int[] leftAngleAry = GetObliqueCellAry(board, isLeftAngleCells);

		return isWin(target, leftAngleAry);
	}

	private bool JudgeRightAngle(BoardCell.CellStates target, int[][] board)
	{
		bool[,] isRightAngleCells = 
		{
			{false, false, true},
			{false, true, false},
			{true, false, false}
		};
		int[] rightAngleAry = GetObliqueCellAry(board, isRightAngleCells);

		return isWin(target, rightAngleAry);
	}

	private int[] GetObliqueCellAry(int[][] board, bool[,] isObliqueCells)
	{
		int[] obliqueCellAry = new int[board.Length];

		for (int i = 0; i < board.Length; i++)
		{
			for(int j = 0; j < board[i].Length; j++)
			{
				if (isObliqueCells[i, j]) {
					obliqueCellAry[i] = board[i][j];
				}
			}
		}

		return obliqueCellAry;
	}

	private bool isWin(BoardCell.CellStates target, int[] stateAry)
	{
		return stateAry.All (state => state == CellStateToInt(target));
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

	private bool IsDraw(int[][] board)
	{
		return GetEmptyCellCount(board) == 0;
	}

	private int GetEmptyCellCount(int[][] board)
	{
		return board
			.SelectMany (ary => ary)
			.ToList()
			.FindAll (i => i == EMPTY_CELL)
			.Count ();
	}
}