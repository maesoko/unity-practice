using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarkChanger : MonoBehaviour {

	public Sprite player1Mark;
	public Sprite player2Mark;

	public MarkHolder markHolder;

	public void ChangeTurnMark(bool isPlayer1Turn)
	{
		markHolder.Mark = isPlayer1Turn ? player1Mark : player2Mark;

	}

}
