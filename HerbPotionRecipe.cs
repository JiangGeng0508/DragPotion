using Godot;
using Godot.Collections;
public partial class HerbPotionRecipe(Array<Vector2I> herbs, int potionIndex) : Resource
{
	public Array<Vector2I> Ingredients = herbs;
	public int PotionIndex = potionIndex;
}