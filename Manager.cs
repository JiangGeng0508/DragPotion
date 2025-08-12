using Godot;
using Godot.Collections;

public partial class Manager : Node
{
	public PackedScene herbScene = GD.Load<PackedScene>("res://herb.tscn");
	public PackedScene potionScene = GD.Load<PackedScene>("res://potion.tscn");
	public string RecipesDirPath = "res://Assets/Recipes/";
	public Array<HerbPotionRecipe> Recipes = [new([new(1,1)],1)];
	public override void _Ready()
	{
		Global.Manager = this;
		ReadRecipesFile();
	}
	public void ReadRecipesFile()
	{
		using var dir = DirAccess.Open(RecipesDirPath);
		foreach (var file in dir.GetFiles())
		{
			switch (file.GetExtension())
			{
				case "tres":
					var recipe1 = ResourceLoader.Load<HerbPotionRecipe>(RecipesDirPath + file);
					Recipes.Add(recipe1);
					break;
				default:
					continue;
			}
		}
	}
}
