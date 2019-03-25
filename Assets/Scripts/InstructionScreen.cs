using UnityEngine;
using System.Collections;

public class InstructionScreen : MonoBehaviour 
{
	private Instructions instructions;
	void Awake () 
	{
		instructions = FindObjectOfType<Instructions>();
	}
	
	public void Next () 
	{
		instructions.ShowNext();
	}

	public void Previous () 
	{
		instructions.ShowPrevious();
	}

	public void Skip()
	{
		instructions.Skip();
	}
}
