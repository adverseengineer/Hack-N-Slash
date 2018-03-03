using UnityEngine;
using System.Collections;

[AddComponentMenu("Actors/Player")]
public sealed class Player : Actor {

	public int XP;
	[Range(-500,500)] public int karma;
	public AnimationCurve levelCurve;
	public AnimationCurve lootCurve;
	private float MercantileFactor;

	//increases as you get more and more tired
	//0-500 in 48 hours
	[Range(0,500)] public int fatigue;
	//0 = well rested, +20 SP, +5 to all skills, +10% XP gain
	//100 = could use a nap, <no effects>
	//300 = tired, -10% movement speed, -20% to SP, MP, and FP regen, -20 speech, -10 barter -10 security
	//500 = walking dead, -30% movement speed, -100% SP regen, <may pass out without warning>
	//500+ = if by chance you never pass out, you will die after fatigue reaches 600

	//increases the longer you go without food
	//0-500 in 72 hours
	[Range(-100,500)] public int hunger;
	//-100 = glutted, -10% movement speed
	//0 = sated, <no effects> +10% HP-SP-MP-FP regen
	//100 = a bit peckish, <no effects>
	//300 = starving, <edges of screen blur>, +10% regen to all meters
	//500 = emaciated, <die>


	//increases the longer you go without water
	//0-500 in 72 hours
	[Range(-100,500)] public int thirst;
	//-100 = bloated, -10% movement speed
	//0 = hydrated, +10 MP, +10 FP
	//100 = dry, <no effects>
	//300 = parched, -10% MP regen
	//500 = dessicated, <die>


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

	public IEnumerator IncreaseNeeds()
	{
		while(true)
		{
			fatigue++;
			hunger++;
			thirst++;

			yield return new WaitForSeconds(1);
		}
	}

	void Start()
	{
		StartCoroutine(IncreaseNeeds());
	}

	void Update()
	{

	}

	public Item BrewPotion(Ingredient ingred1, Ingredient ingred2)
	{
		//TODO: (2 args) if any of a potions effects match the other potion, keep that effect
		return null;
	}

	public Item BrewPotion(Ingredient ingred1, Ingredient ingred2, Ingredient ingred3)
	{ 
		//TODO: (3 args) if any of a potions effects match the other potion, keep that effect.
		return null;
	}
}
