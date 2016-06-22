using UnityEngine;
using System.Collections;
using System.Linq;

public class JudgeManager {

	public bool Judge(CellStates target, int[][] board)
	{
		return JudgeHorizon (target, board) ||
			JudgeVertical (target, board) ||
			JudgeOblique (target, board);
	}

	public bool IsDraw(int[][] board)
	{
		return GetEmptyCellCount(board) == 0;
	}

	private bool JudgeHorizon(CellStates target, int[][] board)
	{
		for (int i = 0; i < board.Length; i++)
		{
			if (isWin (target, board [i])) return true;
		}

		return false;
	}

	private bool JudgeVertical(CellStates target, int[][] board)
	{
		int[] verticalAry = new int[board.Length];

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

	private bool JudgeOblique(CellStates target, int[][] board)
	{
		return JudgeLeftOblique (target, board) || JudgeRightOblique (target, board);
	}

	private bool JudgeLeftOblique(CellStates target, int[][] board)
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

	private bool JudgeRightOblique(CellStates target, int[][] board)
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

	private bool isWin(CellStates target, int[] stateAry)
	{
		return stateAry.All (state => state == BoardManager.CellStateToInt(target));
	}

	private int GetEmptyCellCount(int[][] board)
	{
		return board
			.SelectMany (ary => ary)
			.ToList()
			.FindAll (i => i == BoardManager.EMPTY_CELL)
			.Count ();
	}
}
