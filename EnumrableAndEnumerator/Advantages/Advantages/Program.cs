using Advantages;

//Random random = new Random();
////By adding IEnumarble interface in the class, it become iterable.
//DogShelter dogShelter = new();

//foreach(var dog in dogShelter)
//{
//    if (!dog.IsGoodBoy)
//        dog.GiveThreat(random.Next(1, 3));
//    else
//        dog.GiveThreat(random.Next(4,9));
//}




//After yield return we can see results step by step before it executes till the end


var numbers = Calculator.GetEvenNumbers(10000000);
foreach (var number in numbers)
{
    Console.WriteLine(number);
}