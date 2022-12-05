using System.Diagnostics;
using DnD_MobAttackCalculator;

LoopHitsPerAc(false);
LoopHitsPerAc(true);
Console.ReadLine();

void LoopHitsPerAc(bool a)
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine($"Advantage = {a}");
    Console.WriteLine();

    for (var i = 10; i <= 30; i++)
    {
        CalcHits(i, a);
    }
}

void CalcHits(int i, bool b)
{
    const int attackBonus = 9;
    const int attackers = 8;

    var rollToHit = i - attackBonus;
    int hits;

    if (IsCategory(20, 21))
        hits = Hits((decimal)0.05);
    else if (IsCategory(19, 20))
        hits = Hits((decimal)0.1);
    else if (IsCategory(17, 18))
        hits = Hits((decimal)0.2);
    else if (IsCategory(15, 17))
        hits = Hits((decimal)0.25);
    else if (IsCategory(13, 15))
        hits = Hits((decimal)0.34);
    else if (IsCategory(6, 13))
        hits = Hits((decimal)0.5);
    else if (IsCategory(1, 1))
        hits = attackers;
    else
        hits = 0;

    Console.WriteLine($"AC: {i} => Hits: {hits}");

    bool IsCategory(int acForOrdinary, int acForAdvantage)
    {
        return rollToHit >= acForOrdinary && b is false || (b && rollToHit >= acForAdvantage);
    }

    int Hits(decimal modifier)
    {
        return (int)Math.Round(attackers * modifier, MidpointRounding.ToZero);
    }
}






// void Temp()
// {
//     const int attackBonus = 9;
//     const int attackers = 8;
//
//     if (GetHits(attackers, out var round)) 
//         return round;
//
//     for (var i = 10; i < 30; i++)
//     {
//         var rollToHit = i - attackBonus;
//     }
// }


// bool GetHits(int rollToHit, int attackers, out decimal round)
// {
//     bool IsHit(HitCategory category, Advantage state)
//     {
//         return state switch
//         {
//             Advantage.Disadvantage => rollToHit >= category.disadvantageRollNeeded,
//             Advantage.Regular => rollToHit >= category.regularRollNeeded,
//             Advantage.Advantage => rollToHit >= category.advantageRollNeeded,
//             _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
//         };
//     }
//
//     round = 0;
//     var categories = new HitCategory[]
//     {
//         new()
//         {
//             advantageRollNeeded = 21,
//             disadvantageRollNeeded = 19,
//             regularRollNeeded = 20,
//             modifier = (decimal)0.05
//         },
//         new()
//         {
//             advantageRollNeeded = 20, disadvantageRollNeeded = 17, regularRollNeeded = 19, modifier = (decimal)0.1
//         },
//         new()
//         {
//             advantageRollNeeded = 19, disadvantageRollNeeded = 15, regularRollNeeded = 17, modifier = (decimal)0.2
//         },
//         new()
//         {
//             advantageRollNeeded = 17, disadvantageRollNeeded = 13, regularRollNeeded = 15, modifier = (decimal)0.25
//         },
//         new()
//         {
//             advantageRollNeeded = 15, disadvantageRollNeeded = 6, regularRollNeeded = 13, modifier = (decimal)0.34
//         },
//         new()
//         {
//             advantageRollNeeded = 13, disadvantageRollNeeded = 1, regularRollNeeded = 6, modifier = (decimal)0.5
//         },
//         new() { advantageRollNeeded = 1, disadvantageRollNeeded = 1, regularRollNeeded = 1, modifier = 1 }
//     };
//
//     for (var index = 0; index < categories.Length; index++)
//     {
//         var category = categories[index];
//         if (!IsHit(category, Advantage.Disadvantage))
//             continue;
//
//         round = (int)Math.Round(attackers * category.modifier, MidpointRounding.ToZero);
//         return true;
//     }
//
//     return false;
// }