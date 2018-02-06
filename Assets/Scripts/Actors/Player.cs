using UnityEngine;
using System.Collections;

[AddComponentMenu("Actors/Player")]
public sealed class Player : Actor {

	public int XP;
	[Range(-500,500)] public int karma;
	public AnimationCurve  levelCurve;

	private float MercantileFactor;

	private float ArcaneProgress;
	private float AlchemyProgress;
	private float SurvivalProgress;
	private float RepairProgress;
	private float SecurityProgress;
	private float SpeechProgress;
	private float BarterProgress;
	private float SneakProgress;
	private float LightArmorProgress;
	private float MediumArmorProgress;
	private float HeavyArmorProgress;
	private float BlockProgress;
	private float OneHandedProgress;
	private float TwoHandedProgress;
	private float MarksmanProgress;

	public sealed override void UpdateStatus(){}
}
