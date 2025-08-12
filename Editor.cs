using Godot;
using Godot.Collections;

public partial class Editor : Control
{
	//HerbIcon : $"res://Assets/Herb/{id}.png"
	//PotionIcon : $"res://Assets/Potions/Icon{id}.png"

	//HerbSavePath : "res://Scene/Herbs/Herb{id}.tscn"
	//PotionSavePath : "res://Scene/Potions/Potion{id}.tscn"

	public PackedScene herbScene = GD.Load<PackedScene>("res://herb.tscn");
	public PackedScene potionScene = GD.Load<PackedScene>("res://potion.tscn");
	public PackedScene ItemVectorScene = GD.Load<PackedScene>("res://item_vector.tscn");
	public string RecipesDirPath = "res://Assets/Recipes/";
	public void AddVector()
	{
		var itemVector = ItemVectorScene.Instantiate();
		GetNode("Vectors").AddChild(itemVector);
	}
	public void RemoveVector()
	{
		var vectors = GetNode("Vectors");
		if (vectors.GetChildCount() == 0) return;
		var lastVector = vectors.GetChild(vectors.GetChildCount() - 1);
		// vectors.RemoveChild(lastVector);
		lastVector.QueueFree();
	}
	public void SaveRecipe()
	{
		var ingredient = new Array<Vector2I>();
		var vectors = GetNode("Vectors").GetChildren();
		foreach (var vector in vectors)
		{
			if (vector is ItemVector itemVector)
			{
				ingredient.Add(new Vector2I(itemVector.ItemCount.X, itemVector.ItemCount.Y));
			}
		}
		var result = GetNode<ItemVector>("Result").ItemCount;
		var recipe = new HerbPotionRecipe(ingredient, result.X);
		ResourceSaver.Save(CastRecipeToJSON(recipe), RecipesDirPath + "Recipe.json");
	}
	public Json CastRecipeToJSON(HerbPotionRecipe recipe)
	{
		var json = new Json();
		var data = new Dictionary<int,int>();
		data[0] = recipe.PotionIndex;
		foreach (var item in recipe.Ingredients)
		{
			data[item.X] = item.Y;
		}
		json.Data = data;
		return json;
	}
}
