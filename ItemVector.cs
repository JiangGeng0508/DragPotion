using Godot;
using System;

public partial class ItemVector : VBoxContainer
{
	[Export]
	public string IconPath { get; set; }
	
	public override void _Ready()
	{
		if (IconPath == null) return;
	}
}
