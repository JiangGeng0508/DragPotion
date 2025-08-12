using Godot;

public static class Global
{
	public static Manager Manager;

	public static void Save(Node node,string path)
	{
		var scene = new PackedScene();
		if (scene.Pack(node) == Error.Ok)
		{
			ResourceSaver.Save(scene, path, ResourceSaver.SaverFlags.ChangePath);
		}
		else
		{
			GD.Print("Error saving herb");
		}
	}
}