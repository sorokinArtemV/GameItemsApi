﻿using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemServiceCore.Entities.ItemTypes;

public class Armor : BaseItem
{
    public int Id { get; set; }
    public string ArmorType { get; set; } = default!;

    public int ArmorValue { get; set; }
    public List<ArmorEffect> SpecialEffects { get; set; } = [];
}