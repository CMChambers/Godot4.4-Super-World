using Godot;
using System;

[Tool]
[GlobalClass]
public partial class NoiseLayer : Resource
{
  public enum NoiseSource { Perlin, Simplex, Image, Random }


  [Export] public NoiseSource noiseSource;
  [Export] public Image noiseImage;
  [Export(PropertyHint.Range, "0,1,0.01")] public Vector2 offset;
  [Export] public Vector2 moveSpeed;

  [Export] public float frequency = 1;
  [Export] public float amplitude = 1;
  [Export] public int octaves = 1;
  [Export(PropertyHint.Range, "0,1,0.01")] public float frequencyDecayRate = 1;
  [Export(PropertyHint.Range, "0,1,0.01")] public float amplitudeDecayRate = 1;
  [Export(PropertyHint.Range, "0,1,0.01")] public float ceiling;
  [Export(PropertyHint.Range, "0,1,0.01")] public float floor;
  [Export] public Curve heightCurve;


}
