using Godot;
using Godot.Collections;
using System.Collections.Generic;

public partial class Pot : Node2D
{
	public Label herbsLabel;
	public int[] Herbs = new int[7];
	public List<DraggableItem> nodes = [];
	public override void _Ready()
	{
		herbsLabel = GetNode<Label>("HerbsLabel");
	}

	public void OnBodyEntered(Node2D node)
	{
		if (node is Herb herb)
		{
			Herbs[herb.Index]++;
			nodes.Add(herb);
			UpdateLabel();
		}
	}
	public void OnBodyExited(Node2D node)
	{
		if (node is Herb herb)
		{
			Herbs[herb.Index]--;
			nodes.Remove(herb);
			UpdateLabel();
		}
	}
	public void OnCheckButtonPressed()
	{
		var recipes = Global.Manager.Recipes;
		GD.Print($"Having {recipes.Count} recipes");
		int index = 0;
		foreach (var recipe in recipes)
		{
			GD.Print(recipe.Ingredients.ToString() + " => " + recipe.PotionIndex);
			index = recipe.PotionIndex;
			foreach (var ingredient in recipe.Ingredients)
			{
				if (Herbs[ingredient.X] != ingredient.Y)
				{
					index = 0;
					break;
				}
			}
			if (index != 0) break;
		}
		if (index == 0)
		{
			GD.Print("No matching recipe found");
			return;
		}
		foreach (var node in nodes)
		{
			node.QueueFree();
		}
		UpdateLabel();
		var potion = GD.Load<PackedScene>($"res://Scenes/Potions/Potion{index}.tscn").Instantiate<DraggableItem>();
		AddChild(potion);
	}
	public void UpdateLabel()
	{
		var herbString = "";
		foreach (var herbIndex in Herbs)
		{
			herbString += $"{herbIndex}, ";
			if (herbIndex % 8 == 7)
				herbString += "\n";
		}
		herbsLabel.Text = herbString;
	}
}
