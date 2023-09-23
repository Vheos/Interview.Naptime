using System.Linq;

public class ShooterPool : AComponentPool<Shooter>
{
	protected override Shooter Prefab
	=> Settings.Game.ShooterPrefab;
	protected override int MaxActive
		=> Settings.UI.CubeToggleAmounts.Max();
}
