using Godot;
using System;

[Tool]
[GlobalClass]
public partial class NoiseLayerManager : Resource
{
    [Export] public string randomSeed = "random seed";
    [Export] public float amplification = 1.0f;
    [Export] public MaskLayer maskLayer;
    [Export] public NoiseLayer[] noiseLayers;
}
