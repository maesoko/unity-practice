using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class Test {

	[Test]
	public void EditorTest()
	{
		//Arrange
		var gameObject = new GameObject();

		//Act
		//Try to rename the GameObject
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;

		//Assert
		//The object has a new name
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}

	[Test]
	public void InvertTurnTest()
	{
		BoardManager manager = new BoardManager ();
		manager.InvertTurn ();

		Assert.IsTrue (manager.IsPlayer1Turn == false);
	}
}
