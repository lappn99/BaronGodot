using Godot;
using System;

public class GameSignals : Node
{
    [Signal]
    public delegate void UpdateUI(int year);
    [Signal]
    public delegate void NextTurn();
}
