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
		using var dir = DirAccess.Open(RecipesDirPath);
		foreach (var file in dir.GetFiles())
		{
			if (file.GetExtension() == "json")
			{
				using var fileA = FileAccess.Open(RecipesDirPath + file, FileAccess.ModeFlags.Read);
				var jsonString = fileA.GetAsText();
				var json = new Json();
				var err = json.Parse(jsonString);
				if (err != Error.Ok)
				{
					GD.Print("Error parsing JSON: " + err);
					continue;
				}
				var data = new Dictionary<int, int>((Dictionary)json.Data);
				var potion = data[0];
				var herbs = new Array<Vector2I>();
				foreach (var key in data.Keys)
				{
					if (key == 0) continue;
					herbs.Add(new Vector2I(key, data[key]));
				}
				var recipe = new HerbPotionRecipe(herbs, potion);
				recipes.Add(recipe);
			}
		}
	}
}
