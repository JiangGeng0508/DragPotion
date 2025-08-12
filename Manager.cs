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
				data.TryGetValue(0, out var potion);
				GD.Print("Potion: " + potion);
				var herbs = new Array<Vector2I>();
				foreach (var key in data.Keys)
				{
					if (key == 0) continue;
					if (!data.TryGetValue(key, out var value)) continue;
					GD.Print("Herb: " + key + " x " + value);
					herbs.Add(new Vector2I(key, value));
				}
				var recipe = new HerbPotionRecipe(herbs, potion);
				Recipes.Add(recipe);
			}
		}
	}
}
