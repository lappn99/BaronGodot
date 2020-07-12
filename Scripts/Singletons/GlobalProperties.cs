using Godot;
using System;

public class GlobalProperties : Node
{

    private int _tileSize;

    public int TileSize{get => _tileSize; set => _tileSize = value;}

    public override void _Ready()
    {
        
    }


}
