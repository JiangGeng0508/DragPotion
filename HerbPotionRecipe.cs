using Godot;
using Godot.Collections;
[GlobalClass]
public partial class HerbPotionRecipe : Resource
{
	[Export]
	public Array<Vector2I> Ingredients { get; set; }
	[Export]
	public int PotionIndex { get; set; }
	public HerbPotionRecipe(Array<Vector2I> herbs, int potionIndex)
	{
		Ingredients = herbs;
		PotionIndex = potionIndex;
	}
	public HerbPotionRecipe() { }
}
