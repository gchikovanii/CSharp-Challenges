Console.WriteLine("Enter how many days temp you want");
int days = int.Parse(Console.ReadLine());

int[] temperatures = new int[days];
string[] conditions = { "Sunny", "Rainy", "Snowy" };
string[] weatherConditions = new string[days];
Random random = new Random();
for (int i = 0; i < days; i++)
{
    temperatures[i] = random.Next(-10, 40);
    weatherConditions[i] = conditions[random.Next(conditions.Length)];
}
Console.WriteLine("Average temp is " + average(temperatures));
Console.WriteLine("Min value is " + minValue(temperatures));
Console.WriteLine("Max value is " + maxValue(temperatures));
Console.WriteLine("Common " + commonInArray(weatherConditions));

//Complecity Time is (O(n^2) 
//string mostCommon(string[] conditions)
//{
//    int count = 0;
//    string current = "";
//    if (conditions == null || conditions.Length == 0)
//        return string.Empty;
//    for (int i = 0; i < conditions.Length; i++)
//    {
//        int tempCount = 1;
//        for (int j = i + 1; j < conditions.Length; j++)
//        {
//            if (conditions[i] == conditions[j])
//                tempCount++;
//        }
//        //Case if it's more than 50% return straight away
//        if (tempCount > (conditions.Length / 2.0))
//        {
//            current = conditions[i];
//            return current;
//        }

//        if (tempCount > count)
//        {
//            count = tempCount;
//            current = conditions[i];
//        }
//    }
//    return current;
//}
//Time Complecity O(n) 
string commonInArray(string[] conditions)
{
    if (conditions == null || conditions.Length == 0)
        return string.Empty;

    Dictionary<string, int> keyValuePairs = new();
    //Set keys and values. Key is condition name, int is count
    foreach (var con in conditions)
    {
        if (keyValuePairs.ContainsKey(con))
            keyValuePairs[con]++;
        else
            keyValuePairs[con] = 1;
    }
    int maxCount = 0;
    string mostCommon = "";
    //Find most common
    foreach (var item in keyValuePairs)
    {
        if (item.Value > maxCount)
        {
            maxCount = item.Value;
            mostCommon = item.Key;
        }
    }
    return mostCommon;
}

double average(int[] temutures)
{
    double sum = 0;
    for (int i = 0; i < temutures.Length; i++)
    {
        sum += temutures[i];
    }
    return sum / temutures.Length;
}

int maxValue(int[] temperatures)
{
    var maxValue = temperatures[0];
    for (int i = 1; i < temperatures.Length; i++)
    {
        if (maxValue < temperatures[i])
            maxValue = temperatures[i];
    }
    return maxValue;
}
int minValue(int[] temperatures)
{
    var maxValue = temperatures[0];
    for (int i = 1; i < temperatures.Length; i++)
    {
        if (maxValue > temperatures[i])
            maxValue = temperatures[i];
    }
    return maxValue;
}

Console.ReadKey();
