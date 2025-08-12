using Godot;
using System;

public partial class ItemVector : VBoxContainer
{
	[Export(PropertyHint.Enum, "Herb,Potion")]
	public string ItemType { get; set; } = "Herb";

	public TextureRect Icon { get; set; }
	public Vector2I ItemCount { get; set; } = new(1, 1);

	public override void _Ready()
	{
		Icon = GetNode<TextureRect>("Bg/Icon");
	}
	public void OnHerbChanged(float index)
	{
		switch (ItemType)
		{
			case "Herb":
				Icon.Texture = ResourceLoader.Load(HerbIconPath((int)index)) as Texture2D;
				break;
			case "Potion":
				Icon.Texture = ResourceLoader.Load(PotionIconPath((int)index)) as Texture2D;
				break;
			default:
				break;
		}
		ItemCount = new((int)index, ItemCount.Y);
	}
	public void OnCountChanged(float index)
	{
		ItemCount = new(ItemCount.X, (int)index);
	}
	public static string HerbIconPath(int index) => $"res://Assets/Herb/{index}.png";
	public static string PotionIconPath(int index) => $"res://Assets/Potions/Icon{index}.png";
}
