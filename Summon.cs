using Godot;
using System;

public partial class Summon : Node2D
{
	public Button button;
	public LineEdit lineEdit;
	public override void _Ready()
	{
		button = GetNode<Button>("VBoxContainer/Button");
		lineEdit = GetNode<LineEdit>("VBoxContainer/LineEdit");
	}
	public void SummonItem()
	{
		var id = lineEdit.Text.ToInt();
		var node = GD.Load<PackedScene>($"res://Scenes/Herbs/Herb{id}.tscn").Instantiate();
		AddChild(node);
	}
	public void OnLineEditChanged(string text)
	{
		if (text.Length > 0)
		{
			var id = text.ToInt();
			if (id > 0 && id < 7)
			{
				button.Icon = GD.Load<Texture2D>($"res://Assets/Herb/{id}.png");
			}
		}
	}
	public void OnEditSubmit(string text) => SummonItem();
}
