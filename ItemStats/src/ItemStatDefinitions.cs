using System.Collections.Generic;
using EntityStates;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats
{
    public partial class ItemStatProvider
    {
        static ItemStatProvider()
        {
            ItemDefs = new Dictionary<ItemIndex, List<ItemStat>>
            {
                [ItemIndex.Bear] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: count => 1f - 1f / (0.15f * count + 1f),
                        statText: "Block Chance"
                    )
                },
                [ItemIndex.Hoof] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 0.14f,
                        statText: "Movement Speed Increase"
                    )
                },
                [ItemIndex.Syringe] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: count => count * 0.15f,
                        statText: "Attack Speed Increase"
                    )
                },
                [ItemIndex.Mushroom] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: count => 0.0225f + 0.0225f * count,
                        statText: "Healing Per Second",
                        // TODO: use a decorator instead of additional param for the formatter
                        formatter: new PercentageFormatter(maxValue: 1f)
                    ),
                    new ItemStat(
                        formula: itemCount => 1.5f + 1.5f * itemCount,
                        statText: "Area Increase",
                        formatter: new IntFormatter("m")
                    )
                },
                [ItemIndex.CritGlasses] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 0.1f,
                        statText: "Additional Crit Chance",
                        formatter: new PercentageFormatter(maxValue: 1f)
                    )
                },
                [ItemIndex.Feather] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Total Additional  Jumps",
                        formatter: new IntFormatter()
                    )
                },
                [ItemIndex.Seed] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Total Heal Hp",
                        formatter: new IntFormatter("HP")
                    )
                },
                [ItemIndex.GhostOnKill] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 30f,
                        statText: "Ghost Duration",
                        formatter: new IntFormatter("s")
                    )
                },
                [ItemIndex.Knurl] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 40f,
                        statText: "Bonus Health",
                        formatter: new IntFormatter("HP")
                    ),
                    new ItemStat(
                        formula: itemCount => itemCount * 1.6f,
                        statText: "Additional Regeneration",
                        formatter: new IntFormatter("HP/s")
                    ),
                },
                [ItemIndex.Clover] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Additional Rerolls",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Medkit] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 10f,
                        statText: "Health Healed",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.Crowbar] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1f + 0.5f * itemCount,
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.Tooth] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 6 * itemCount,
                        statText: "Heal Amount",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.Talisman] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 2f + itemCount * 2f,
                        statText: "Cooldown Reduction",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.Bandolier] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1f - 1f / Mathf.Pow(itemCount + 1, 0.33f),
                        statText: "Drop Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.IceRing] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1.25f + 1.25f * itemCount,
                        statText: "Total Damage"
                    ),
                    new ItemStat(
                        formula: itemCount => 0.08f,
                        statText: "Proc Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.FireRing] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 2.5f + 2.5f * itemCount,
                        statText: "Total Damage"
                    ),
                    new ItemStat(
                        formula: itemCount => 0.08f,
                        statText: "Proc Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.WarCryOnMultiKill] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 2f + 4f * itemCount,
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.SprintOutOfCombat] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 0.3f,
                        statText: "Speed Increase"
                    ),
                },
                [ItemIndex.StunChanceOnHit] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1f - 1f / (0.05f * itemCount + 1f),
                        statText: "Stun Chance Increase",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.WarCryOnCombat] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 2f + 4f * itemCount,
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.SecondarySkillMagazine] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Bonus Stock",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.UtilitySkillMagazine] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 2f,
                        statText: "Bonus Charges",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.AutoCastEquipment] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.5f * Mathf.Pow(0.85f, (itemCount - 1)),
                        statText: "Cooldown Decrease",
                        formatter: new PercentageFormatter()
                    ),
                },
                [ItemIndex.KillEliteFrenzy] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1f + itemCount * 2f,
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.BossDamageBonus] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.2f + 0.2f * (itemCount - 1),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.ExplodeOnDeath] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 12f + 2.4f * (itemCount - 1f),
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                    new ItemStat(
                        formula: itemCount => 3.5f * (1f + (itemCount - 1) * 0.8f),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.HealWhileSafe] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 3f * itemCount,
                        statText: "Regeneration Increase"
                    ),
                },
                [ItemIndex.IgniteOnKill] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 8f + 4f * itemCount,
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                    new ItemStat(
                        formula: itemCount => 1.5f + 1.5f * itemCount,
                        statText: "Duration Increase"
                    ),
                },
                [ItemIndex.WardOnLevel] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 8f + 8f * itemCount,
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                },
                [ItemIndex.NovaOnHeal] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Soul Energy"
                    ),
                },
                [ItemIndex.HealOnCrit] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 4f + itemCount * 4f,
                        statText: "Health per Crit",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.BleedOnHit] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.15f * itemCount,
                        statText: "Bleed Chance Increase",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.SlowOnHit] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 2 * itemCount,
                        statText: "Slow Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.EquipmentMagazine] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Bonus Charges",
                        formatter: new IntFormatter()
                    ),
                    new ItemStat(
                        formula: itemCount => 1 - Mathf.Pow(0.85f, itemCount),
                        statText: "Cooldown Decrease"
                    ),
                },
                [ItemIndex.GoldOnHit] = new List<ItemStat>
                {
                    new ItemStat(
                        //TODO: make run a modifier
                        formula: itemCount => itemCount * 3f * Run.instance.difficultyCoefficient,
                        statText: "Gold per Hit(*)",
                        formatter: new IntFormatter()
                    ),
                    new ItemStat(
                        formula: itemCount => 0.3f,
                        statText: "Proc Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.IncreaseHealing] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Healing Increase"
                    ),
                },
                [ItemIndex.PersonalShield] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 25f,
                        statText: "Shield Health Increase",
                        formatter: new IntFormatter("SP")
                    ),
                },
                [ItemIndex.ChainLightning] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount * 2f,
                        statText: "Total Bounces",
                        formatter: new IntFormatter()
                    ),
                    new ItemStat(
                        formula: itemCount => 20f + 2f * itemCount,
                        statText: "Bounce Range",
                        formatter: new IntFormatter("m")
                    ),
                    new ItemStat(
                        formula: itemCount => 0.25f,
                        statText: "Proc Chance",
                        formatter: new PercentageFormatter(),
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.TreasureCache] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 80f / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                        statText: "Common Chance",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.TreasureCache
                    ),
                    new ItemStat(
                        formula: itemCount =>
                            20f * itemCount / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                        statText: "Uncommon Chance",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.TreasureCache
                    ),
                    new ItemStat(
                        formula: itemCount =>
                            Mathf.Pow(itemCount, 2f) / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                        statText: "Rare Chance",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.TreasureCache
                    ),
                },
                [ItemIndex.BounceNearby] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1f - 100f / (100f + 20f * itemCount),
                        statText: "Hook Chance",
                        modifiers: Modifiers.Clover
                    ),
                    new ItemStat(
                        formula: itemCount => 5f + itemCount * 5f,
                        statText: "Max Enemies Hooked",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.SprintBonus] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.1f + 0.2f * itemCount,
                        statText: "Speed Increase"
                    ),
                },
                [ItemIndex.SprintArmor] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 30f * itemCount,
                        statText: "Sprint Bonus Armor",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.ShockNearby] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 2f * itemCount,
                        statText: "Total Bounces",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.BeetleGland] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Total Guards",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.ShieldOnly] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.5f + (itemCount - 1) * 0.25f,
                        statText: "Max Health Increase"
                    ),
                },
                [ItemIndex.StickyBomb] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.05f * itemCount,
                        statText: "Proc Chance Increase",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.RepeatHeal] = new List<ItemStat>
                {
                    //TODO: need to get masters maxhealth to get actual heal amount
                    new ItemStat(
                        formula: itemCount => 0.1f / itemCount,
                        statText: "Health Fraction/s"
                    ),
                    new ItemStat(
                        formula: itemCount => 1 + itemCount,
                        statText: "Healing per Heal Increase"
                    ),
                },
                [ItemIndex.HeadHunter] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 3f + 5f * itemCount,
                        statText: "Empowering Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.ExtraLife] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Extra Lives",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.AlienHead] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1 - Mathf.Pow(0.75f, itemCount),
                        statText: "Cooldown Reduction",
                        formatter: new PercentageFormatter(2)
                    ),
                },
                [ItemIndex.Firework] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 4 + itemCount * 4,
                        statText: "Firework Count",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Missile] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 3 * itemCount,
                        statText: "Missile Total Damage",
                        formatter: new PercentageFormatter()
                    ),
                    new ItemStat(
                        formula: itemCount => 0.1f,
                        statText: "Proc Chance",
                        formatter: new PercentageFormatter(),
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.Infusion] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 100 * itemCount,
                        statText: "Max Additional Health",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.JumpBoost] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 10 * itemCount,
                        statText: "Boost Length",
                        formatter: new IntFormatter("m")
                    ),
                },
                [ItemIndex.AttackSpeedOnCrit] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.1f + 0.2f * itemCount,
                        statText: "Max Attack Speed"
                    ),
                },
                [ItemIndex.Icicle] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1.5f * itemCount,
                        statText: "Icicle Damage"
                    ),
                    new ItemStat(
                        formula: itemCount => 6 + (itemCount - 1) * 3,
                        statText: "Max Possible Icicles"
                    )
                },
                [ItemIndex.Behemoth] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1.5f + 2.5f * itemCount,
                        statText: "Explosion Radius",
                        formatter: new IntFormatter("m")
                    )
                },
                [ItemIndex.BarrierOnKill] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 15f * itemCount,
                        statText: "Barrier Health",
                        formatter: new IntFormatter("HP")
                    )
                },
                [ItemIndex.BarrierOnOverHeal] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.5f * itemCount,
                        statText: "Barrier From Overheal",
                        formatter: new PercentageFormatter()
                    )
                },
                [ItemIndex.ExecuteLowHealthElite] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1f - 1f / (0.2f * itemCount + 1),
                        statText: "Kill Health Threshold",
                        formatter: new PercentageFormatter()
                    )
                },
                [ItemIndex.EnergizedOnEquipmentUse] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 8f + 4f * (itemCount - 1),
                        statText: "Attack Speed Duration",
                        formatter: new IntFormatter("s")
                    )
                },
                [ItemIndex.TitanGoldDuringTP] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Health Boost",
                        formatter: new PercentageFormatter()
                    ),
                    new ItemStat(
                        formula: itemCount => 0.5f + 0.5f * itemCount,
                        statText: "Damage Boost",
                        formatter: new PercentageFormatter()
                    )
                },
                [ItemIndex.SprintWisp] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Damage Boost",
                        formatter: new PercentageFormatter()
                    )
                },
                [ItemIndex.Dagger] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 1.5f * itemCount,
                        statText: "Dagger Damage",
                        formatter: new PercentageFormatter()
                    )
                },
                [ItemIndex.LunarUtilityReplacement] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 3f * itemCount,
                        statText: "Skill Duration",
                        formatter: new IntFormatter("s")
                    ),
                    new ItemStat(
                        formula: itemCount =>
                        {
                            var maxHealth = LocalUserManager.FindLocalUser(0).cachedBody.maxHealth;
                            var healingPerSecond = maxHealth
                                                   * GhostUtilitySkillState.healFractionPerTick
                                                   * GhostUtilitySkillState.healFrequency;

                            return healingPerSecond;
                        },
                        statText: "Health Healed",
                        formatter: new IntFormatter("HP/s")
                    )
                },
                [ItemIndex.NearbyDamageBonus] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 0.15f * itemCount,
                        statText: "Damage Increase",
                        formatter: new PercentageFormatter()
                    )
                },
                [ItemIndex.TPHealingNova] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => itemCount,
                        statText: "Max Occurrences",
                        formatter: new IntFormatter(),
                        modifiers: Modifiers.TpHealingNova
                    )
                },
                [ItemIndex.ArmorReductionOnHit] = new List<ItemStat>
                {
                    new ItemStat(
                        formula: itemCount => 8f * itemCount,
                        statText: "Duration",
                        formatter: new IntFormatter("s")
                    )
                },
            };
        }
    }
}