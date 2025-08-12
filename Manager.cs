using Godot;
using Godot.Collections;

public partial class Manager : Node
{
	public PackedScene herbScene = GD.Load<PackedScene>("res://herb.tscn");
	public PackedScene potionScene = GD.Load<PackedScene>("res://potion.tscn");
	public string RecipesDirPath = "res://Assets/Recipes/";
	public Array<HerbPotionRecipe> recipes = [];
	public override void _Ready()
	{
		Global.Manager = this;
		ReadRecipesFile();
	}
	public void ReadRecipesFile()
	{
		var dir = DirAccess.Open(RecipesDirPath);
		foreach (var file in dir.GetFiles())
		{
			if (file.GetExtension() == "tres")
			{
				GD.Print("Reading recipe file: "+ RecipesDirPath + file);
				recipes.Add(ResourceLoader.Load<HerbPotionRecipe>(RecipesDirPath + file));
			}
		}
	}
}
