using Godot;
using System;

public class Terrain : TileMap
{
	private int _terrainWidth;
	private int _terrainHeight;

	[Export]
	public int TerrainWidth{get => _terrainWidth; set => _terrainWidth = value; }

	[Export]
	public int TerrainHeight{get => _terrainHeight; set=> _terrainHeight= value;}
	public override void _Ready()
	{
		SetTiles();


	}	

	private void SetTiles()
	{
		for(int x = 0; x < TerrainWidth; x++)
		{
			for(int y = 0; y< TerrainHeight; y++)
			{
				this.SetCellv(new Vector2(x,y),0);

			}

		}


	}
}
