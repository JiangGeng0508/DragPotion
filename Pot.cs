using Godot;
using System;

public partial class Pot : Node2D
{
	public void OnBodyEntered(Node2D node)
	{
		if (node is DraggableItem item)
		{
			GD.Print($"{item.ItemType} {item.Index} entered pot");
		}
	}
}
