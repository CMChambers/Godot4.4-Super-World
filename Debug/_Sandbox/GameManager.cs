using Godot;

namespace CMC.Superworld.Game
{
	public partial class GameManager : Node
	{
		[Export] public bool IsSimpleDevMode = true;

		public override void _Input(InputEvent @event)
		{
			base._Input(@event);
			if (@event.IsActionPressed("ui_cancel"))
			{
				if (IsSimpleDevMode)
				{
					Input.MouseMode = Input.MouseModeEnum.Visible;
				}
			}
		}
	}
}