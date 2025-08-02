using Godot;

[Tool]
[GlobalClass]
public partial class MaskLayer : Resource
{
    [Export] public float innerRadius = 100.0f;
    [Export] public float outerRadius = 150.0f;
    [Export(PropertyHint.Range, "0,1,0.01")] public float outerRadiusHeight = 0.0f;

}