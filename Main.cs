using Godot;
using System;

public partial class Main : Node2D
{
	public void ChangeToEditorScene() => GetTree().ChangeSceneToFile("res://editor.tscn");
}
