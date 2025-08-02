using Godot;
using System;

[Tool]
[GlobalClass]
public partial class TerrainGeneratorSettings : Resource
{

    [Export] public GroundGenerator groundGenerator;
    // [Export] public LandmarkGenerator landmarkGenerator;
    // [Export] public StructureGenerator structureGenerator;
    // [Export] public FeatureGenerator featureGenerator;
    // [Export] public PropGenerator propGenerator;
}
