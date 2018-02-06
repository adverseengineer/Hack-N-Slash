using UnityEngine;
using System.Collections;

[AddComponentMenu("Actors/NPC")]
public sealed class NPC : Actor {

	public enum CombatStyle
	{
		Berserker = 0, //dual wielding shortswords, medium or heavy armor
		Knight = 1, //longsword and shield, medium armor. just as God intended
		Ranger = 2, //longbow and arrow, light armor
		Artificer = 3, //heavy armor, crossbow, caltrops
		Thief = 4, //two daggers, light or medium armor
		Spellsword = 5, //longsword and spellbook or scroll, light armor
		Druid = 6, //light armor, staff and scroll
		Tank = 7 //heavy armor, warhammer or greatsword
		//TODO: add more archetypes
	};

	public bool essential;
	[Range(0,1f)] public float disposition;
	public CombatStyle combatStyle;

	public sealed override void UpdateStatus(){}
}
