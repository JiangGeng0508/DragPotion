using Godot;
using Godot.Collections;

public partial class Manager : Node
{
	public PackedScene herbScene = GD.Load<PackedScene>("res://herb.tscn");
	public PackedScene potionScene = GD.Load<PackedScene>("res://potion.tscn");
	public string RecipesDirPath = "res://Assets/Recipes/";
	public Array<Potion> potions = [];
	public override void _Ready()
	{
		Global.Manager = this;
	}
	public void ReadRecipesFile()
	{
		var dir = DirAccess.Open(RecipesDirPath);
		foreach (var file in dir.GetFiles())
		{
			if (file.GetExtension() == "tres")
			{

			}
		}
	}
}