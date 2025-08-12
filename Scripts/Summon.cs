using Godot;
using System;

public partial class Summon : Node2D
{
	public Button button;
	public SpinBox spin;
	public override void _Ready()
	{
		button = GetNode<Button>("VBoxContainer/Button");
		spin = GetNode<SpinBox>("VBoxContainer/SpinBox");
	}
	public void SummonItem()
	{
		var id = (int)spin.Value;
		var node = GD.Load<PackedScene>($"res://Scenes/Herbs/Herb{id}.tscn").Instantiate();
		AddChild(node);
	}
	public void OnSpinBoxValueChaged(float value)
	{
		button.Icon = GD.Load<Texture2D>($"res://Assets/Herb/{value}.png");
	}
	public void OnEditSubmit(string text) => SummonItem();
}
