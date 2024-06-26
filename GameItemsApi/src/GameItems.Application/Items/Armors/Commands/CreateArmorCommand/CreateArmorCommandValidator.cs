﻿using FluentValidation;

namespace GameItems.Application.Items.Armors.Commands.CreateArmorCommand;

public class CreateArmorCommandValidator : AbstractValidator<CreateArmorCommand>
{
    private readonly IEnumerable<string> _boundTypes =
    [
        "BindOnPickup",
        "BindOnEquip",
        "BindOnUse"
    ];

    private readonly IEnumerable<string> _classes =
    [
        "Any",
        "Warrior",
        "Paladin",
        "Hunter",
        "Rogue",
        "Priest",
        "Shaman",
        "Mage",
        "Warlock",
        "Druid"
    ];


    private readonly IEnumerable<string> _qualityTypes =
    [
        "Poor",
        "Common",
        "Uncommon",
        "Rare",
        "Epic",
        "Legendary"
    ];

    private readonly IEnumerable<string> _races =
    [
        "Any",
        "Human",
        "Orc",
        "Dwarf",
        "Night Elf",
        "Gnome",
        "Undead",
        "Tauren",
        "Gnome",
        "Troll"
    ];

    private readonly IEnumerable<string> _armorTypes =
    [
        "Cloth",
        "Leather",
        "Mail",
        "Plate",
        "Shield"
    ];

    private readonly IEnumerable<string> _itemType =
    [
        "weapon",
        "armor"
    ];


    public CreateArmorCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(3, 30)
            .WithMessage("Name must be between 3 and 30 characters");

        RuleFor(dto => dto.Description)
            .Length(3, 300)
            .WithMessage("Description must be between 3 and 300 characters");

        RuleFor(dto => dto.Quality)
            .Must(_qualityTypes.Contains)
            .WithMessage("Quality must be one of the following: " + string.Join(", ", _qualityTypes));
        
        RuleFor(dto => dto.ItemType)
            .Must(_itemType.Contains)
            .WithMessage("ItemType must be one of the following: " + string.Join(", ", _itemType));

        RuleFor(dto => dto.Icon)
            .Length(3, 100)
            .WithMessage("Icon must be between 3 and 100 characters");

        RuleFor(dto => dto.BoundType)
            .Must(_boundTypes.Contains)
            .WithMessage("BoundType must be one of the following: " + string.Join(", ", _boundTypes));

        RuleFor(dto => dto.Durability)
            .NotEmpty()
            .WithMessage("Durability is required")
            .InclusiveBetween(1, 150)
            .WithMessage("Durability must be between 1 and 60");

        RuleFor(dto => dto.ItemLevel)
            .NotEmpty()
            .WithMessage("ItemLevel is required")
            .InclusiveBetween(1, 150)
            .WithMessage("ItemLevel must be between 1 and 60");

        RuleFor(dto => dto.StackSize)
            .NotNull()
            .WithMessage("StackSize must not be null")
            .InclusiveBetween(1, 100)
            .WithMessage("StackSize must be between 1 and 100");


        RuleFor(dto => dto.RequiredClasses)
            .NotNull() // Validates that the list is not null
            .WithMessage("RequiredClasses list must not be null")
            .Must(races => races != null && races.All(race => _classes.Contains(race)))
            .WithMessage("Class must be one of the following: " + string.Join(", ", _classes));


        RuleFor(dto => dto.RequiredRace)
            .NotNull() // Validates that the list is not null
            .WithMessage("RequiredRace list must not be null")
            .Must(races => races != null && races.All(race => _races.Contains(race)))
            .WithMessage("Race must be one of the following: " + string.Join(", ", _races));

        RuleFor(dto => dto.RequiredLevel)
            .NotEmpty()
            .WithMessage("RequiredLevel is required")
            .InclusiveBetween(1, 60)
            .WithMessage("RequiredLevel must be between 1 and 60");


        RuleFor(dto => dto.ArmorType)
            .Must(_armorTypes.Contains)
            .WithMessage("WeaponType must be one of the following: " + string.Join(", ", _armorTypes));

        RuleFor(dto => dto.StartsQuest)
            .NotNull();

        RuleFor(dto => dto.IsConjured)
            .NotNull();

        RuleFor(dto => dto.IsUnique)
            .NotNull();

        RuleFor(dto => dto.IsQuestItem)
            .NotNull();

        RuleFor(dto => dto.IsLocked)
            .NotNull();

        RuleFor(dto => dto.IsLootable)
            .NotNull();
    }
}