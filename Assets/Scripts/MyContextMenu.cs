using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyContextMenu : MonoBehaviour
{
	[ContextMenuItem("Add HP", "AddHP")]
	public int Blood;

	public Vector3 Position;

	public void AddHP()
	{
		Blood += 10;
	}

	/// <summary>
	/// 会显示在Inspector右击面板
	/// </summary>
	[ContextMenu("初始化位置")]
	public void InitPosition()
	{
		Position = Vector3.one;
	}
}
