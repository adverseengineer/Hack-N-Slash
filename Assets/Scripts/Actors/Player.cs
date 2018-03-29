using UnityEngine;
using System.Collections;

[AddComponentMenu("Actors/Player")]
public sealed class Player : Actor {

	public int XP;
	[Range(-500,500)] public int karma;
	public AnimationCurve levelCurve;
	public AnimationCurve lootCurve;
	private float MercantileFactor;

	void Start()
	{
		alive = true;
	}

	private float ArcaneProgress;
	private float AlchemyProgress;
	private float SurvivalProgress;
	private float RepairProgress;
	private float SecurityProgress;
	private float SpeechProgress;
	private float StealthProgress;
	private float LightArmorProgress;
	private float MediumArmorProgress;
	private float HeavyArmorProgress;
	private float BlockProgress;
	private float OneHandedProgress;
	private float TwoHandedProgress;
	private float MarksmanProgress;
}
