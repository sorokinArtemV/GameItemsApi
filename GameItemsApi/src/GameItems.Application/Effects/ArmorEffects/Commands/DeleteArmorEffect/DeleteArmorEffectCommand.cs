﻿using MediatR;

namespace GameItems.Application.Effects.ArmorEffects.Commands.DeleteArmorEffect;

public class DeleteArmorEffectCommand(int effectId, int armorId) : IRequest
{
    public int Id { get; set; } = effectId;
    public int ArmorId { get; set; } = armorId;
}