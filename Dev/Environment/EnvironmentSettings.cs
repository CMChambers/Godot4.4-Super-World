using Godot;
using System;

[Tool]
[GlobalClass]
public partial class EnvironmentSettings : Resource
{
    public enum EnvironmentType { World, Dungeon }
    [Export] public EnvironmentType environmentType;
}
