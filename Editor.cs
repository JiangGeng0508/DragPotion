using Godot;
using System;

public partial class Editor : Control
{
	//HerbIcon : $"res://Assets/Herb/{id}.png"
	//PotionIcon : $"res://Assets/Potions/Icon{id}.png"

	//HerbSavePath : "res://Scene/Herbs/Herb{id}.tscn"
	//PotionSavePath : "res://Scene/Potions/Potion{id}.tscn"

	public PackedScene herbScene = GD.Load<PackedScene>("res://herb.tscn");
	public PackedScene potionScene = GD.Load<PackedScene>("res://potion.tscn");
	public PackedScene ItemVectorScene = GD.Load<PackedScene>("res://item_vector.tscn");
	public override void _Ready()
	{
	}
	public void AddVector()
	{
		var itemVector = ItemVectorScene.Instantiate();
		AddChild(itemVector);
	}
	
}
