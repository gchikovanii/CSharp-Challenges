using System.Text;

string s = "PAYPALISHIRING";
Console.WriteLine(Convert(s, 4));
static string Convert(string s, int numRows)
{
    if (numRows == 1) return s;
    StringBuilder[] rows = new StringBuilder[Math.Min(numRows, s.Length)];
    for (int i = 0; i < rows.Length; i++)
        rows[i] = new StringBuilder();
    int currentRow = 0;
    bool goingDown = false;

    foreach (char c in s)
    {
        rows[currentRow].Append(c);
        if (currentRow == 0 || currentRow == numRows - 1) 
            goingDown = !goingDown;
        currentRow += goingDown ? 1 : -1;
    }

    StringBuilder result = new StringBuilder();
    foreach (StringBuilder row in rows)
        result.Append(row);

    return result.ToString();

}
