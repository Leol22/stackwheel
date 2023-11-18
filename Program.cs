string path = @$"./{args[0]}";
string[] rawcode = File.ReadAllLines(path);
//parsing
List<string> rawcommands = new List<string>();   
foreach (string line in rawcode)
{
    if (line.Length > 0 && line[0]!='/')
    { rawcommands.Add(line); }
}
string[] code=new string[rawcommands.Count];
for (int i = 0; i < code.Length; i++)
{
    code[i]= rawcommands[i];
}

//setting up
List<int>[] stackwheel = new List<int>[16];
int[] intwheel = new int[16];
for (int i = 0; i < intwheel.Length; i++)
{
    intwheel[i] = 0;
}
int acc = 0;

//runtime
int pointer = 0;
bool active = true;
bool test = false;
while (active)
{
    if (code[pointer][0] != '#') {
        switch (code[pointer])
        {
            case "HLT":
                active = false;
                break;
            case ">3>":
                List<int> temp = stackwheel[15];
                for (int i = 1; i < stackwheel.Length; i++)
                {
                    stackwheel[i] = stackwheel[i - 1];
                }
                stackwheel[0] = temp;
                break;
            case "<3<":
                List<int> temp2 = stackwheel[0];
                for (int i = 0; i < stackwheel.Length - 1; i++)
                {
                    stackwheel[i] = stackwheel[i + 1];
                }
                stackwheel[15] = temp2;
                break;
            case ">2>":
                int temp3 = intwheel[15];
                for (int i = 1; i < intwheel.Length; i++)
                {
                    intwheel[i] = intwheel[i - 1];
                }
                intwheel[0] = temp3;
                break;
            case "<2<":
                int temp4 = intwheel[0];
                for (int i = 0; i < intwheel.Length - 1; i++)
                {
                    intwheel[i] = intwheel[i + 1];
                }
                intwheel[15] = temp4;
                break;

            case "ADD":
                acc += intwheel[0];
                break;
            case "SUB":
                acc -= intwheel[0];
                break;
            case "MUL":
                acc *= intwheel[0];
                break;
            case "DIV":
                acc /= intwheel[0];
                break;
            case "MOD":
                acc %= intwheel[0];
                break;
            case "OUT":
                Console.WriteLine(acc);
                break;
            case "INP":
                Console.WriteLine("Input please:");
                acc=int.Parse(Console.ReadLine());
                break;
            case "+++":
                acc++;
                break;
            case "---":
                acc--;
                break;
            case "TEQ":
                if (acc == intwheel[0])
                { test = true;}
                else
                { test = false; }
                break;
            case "TGT":
                if (acc > intwheel[0])
                { test = true; }
                else
                { test = false; }
                break;
            case "TLS":
                if (acc < intwheel[0])
                { test = true; }
                else
                { test = false; }
                break;

            default:
                if (code[pointer][1]=='>')
                {
                    int tomove=0;
                    switch (code[pointer][0])
                    {
                        case '3':
                            tomove = stackwheel[0].Last();
                            stackwheel[0].RemoveAt(stackwheel[0].Count-1);
                            break;
                        case '2':
                            tomove= intwheel[0];
                            break;
                        case '1':
                            tomove = acc;
                            break;

                    }

                    switch (code[pointer][2])
                    {
                        case '3':
                            stackwheel[0].Add(tomove);
                            break;
                        case '2':
                            intwheel[0] =tomove;
                            break;
                        case '1':
                            acc = tomove;
                            break;

                    }
                }
                if (code[pointer].Length > 3 && (code[pointer].Substring(0, 3) == "UJP" || (code[pointer].Substring(0, 3) == "JMP" && test==true)))
                {
                    string[] parts = code[pointer].Split(' ');
                    string mark = "#"+parts[1];
                    while (mark != code[pointer])
                    {
                        pointer++;
                        if (pointer == code.Length) pointer = 0;
                    }
                }
                break;
        }
    }
    pointer++;
}
