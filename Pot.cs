using Godot;
using System.Collections.Generic;

public partial class Pot : Node2D
{
	public Label herbsLabel;
	public int[] Herbs = new int[24];
	public List<DraggableItem> nodes = [];
	public override void _Ready()
	{
		herbsLabel = GetNode<Label>("HerbsLabel");
		var herbString = "";
		foreach (var herb in Herbs)
		{
			herbString += $"{herb}, ";
		}
		GD.Print(herbString);
		Herbs.Initialize();
		herbString = "";
		foreach (var herb in Herbs)
		{
			herbString += $"{herb}, ";
		}
		GD.Print(herbString);
	}

	public void OnBodyEntered(Node2D node)
	{
		if (node is DraggableItem item)
		{
			if (item.ItemType == ItemTypeEnum.Herb)
			{
				Herbs[item.Index]++;
				nodes.Add(item);
				UpdateLabel();
			}
		}
	}
	public void OnBodyExited(Node2D node)
	{
		if (node is DraggableItem item)
		{
			if (item.ItemType == ItemTypeEnum.Herb)
			{
				Herbs[item.Index]--;
				nodes.Remove(item);
				UpdateLabel();
			}
		}
	}
	public void OnCheckButtonPressed()
	{
		var testRecipe = new HerbPotionRecipe([1, 2, 3], 2);
		
		foreach (var node in nodes)
		{
			node.QueueFree();
		}
		// Herbs.Clear();
		// nodes.Clear();
		UpdateLabel();
		var potion = GD.Load<PackedScene>($"res://Scenes/Potions/Potion{testRecipe.PotionIndex}.tscn").Instantiate<DraggableItem>();
		AddChild(potion);
	}
	public void UpdateLabel()
	{
		var herbString = "";
		foreach (var herbIndex in Herbs)
		{
			herbString += $"{herbIndex}, ";
		}
		herbsLabel.Text = herbString;
	}
}
public class HerbPotionRecipe(List<int> herbs, int potionIndex)
{
	public List<int> Herbs = herbs;
	public int PotionIndex = potionIndex;
}
