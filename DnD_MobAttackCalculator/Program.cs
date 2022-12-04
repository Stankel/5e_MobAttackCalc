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
        hits = (int)Math.Round(attackers * 0.05, MidpointRounding.ToZero);
    else if (IsCategory(19, 20))
        hits = (int)Math.Round(attackers * 0.1, MidpointRounding.ToZero);
    else if (IsCategory(17, 18))
        hits = (int)Math.Round(attackers * 0.2, MidpointRounding.ToZero);
    else if (IsCategory(15, 17))
        hits = (int)Math.Round(attackers * 0.25, MidpointRounding.ToZero);
    else if (IsCategory(13, 15))
        hits = (int)Math.Round(attackers * 0.34, MidpointRounding.ToZero);
    else if (IsCategory(6, 13))
        hits = (int)Math.Round(attackers * 0.5, MidpointRounding.ToZero);
    else if (IsCategory(1, 1))
        hits = attackers;
    else
        hits = 0;
    Console.WriteLine($"AC: {i} => Hits: {hits}");

    bool IsCategory(int acForOrdinary, int acForAdvantage)
    {
        return rollToHit >= acForOrdinary && b is false || (b && rollToHit >= acForAdvantage);
    }
}

// CalcAcFromInput();
//
// void CalcAcFromInput()
// {
//     var input = Console.ReadLine();
//     var inputArray = input?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//
//     try
//     {
//         armorClass = Convert.ToInt32(inputArray![0]);
//
//         if (int.TryParse(inputArray[1], out var intAdvantage))
//             advantage = intAdvantage != 0;
//         else
//             advantage = Convert.ToBoolean(inputArray[1]);
//     }
//     catch (Exception e)
//     {
//         Console.WriteLine($"Couldn't process input: {e}");
//     }
//
//     CalcHits(armorClass, advantage);
// }
