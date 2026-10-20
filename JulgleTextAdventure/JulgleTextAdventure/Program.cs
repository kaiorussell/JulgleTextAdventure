﻿
// string, område er en funtion, 
using JulgleTextAdventure;

int hp = 5;
int attack = 1;

Main();
void Main()
{
    gameTitle();
}

// Green --> Julge 
// DarkYellow --> Byen
// Gray --> Mall
// DarkCyan --> Fight
// Red --> Game Over
// R.I.N.P = Rest In Not Pink 
void gameTitle()
{
    Console.WriteLine("Velkommen til Julgle Text Adventure!");
    Console.WriteLine("Tryk 'Enter' for at begynde.");
    Console.ReadLine();
    Console.Clear();
    start();
}


void start()
{
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine(
        "Du er en majestætisk sort panter i den majestætiske grønne julgle.\n" +
        "Hele dit liv har du drømmet om at være pink, men du har aldrig vidst hvordan.\n" +
        "Alt dette ændrer sig i dag, hvor du modtager en kupon til en malerboutique i byen.\n" +
        "Det eneste problem er, at du ikke ved hvordan man kommer hen til byen.\n\n" +
        "1: Følg floden \n" + "2: Gå gennem træerne. \n\n" +
        "");
    Console.Write("Hvad gør du: ");
    int Choice = int.Parse(Console.ReadLine());
    Console.Clear();

    if (Choice == 1 || Choice == 2)
    {
        byen();
    }

}

void byen()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;

    Console.WriteLine(
        "Du befinder dig nu i en mellemstor by.\n" +
        "Der er bygninger så langt øjet rækker.\n" +
        "Men gad vide hvor malerboutiquen er..\n" +
        "1: Find et kort \n" + "2: Spørg den søde dame. \n" + "3: Udforsk. \n\n" +
        "");
    Console.Write("Hvad gør du: ");
    int Choice = int.Parse(Console.ReadLine());
    Console.Clear();

    if (Choice == 1)
    {
        Console.WriteLine("Du leder desperat efter et kort, og du vandre ind i en kæmpe bygning kaldt 'storcenter'");
        mall();
    }

    if (Choice == 2)
    {
        Console.WriteLine("Du spørger den søde dame om vej til malerboutiquen. \n" +
            "Damen skriger og gør klar til at slå dig med sin taske! \n");
        Enemy SødDame = new Enemy("Sød Dame", 5, 1);
        if (Combat(SødDame))
        {
            Console.WriteLine("Du absolute destruerer den stakkels dame. \n" +
                "Du finder dog en lille skærm på jorden ved siden af hende. \n" +
                "Når du samler den op er den allerede inde på et mini kort! Wow! \n" +
                "Du finder din kupon og dine læsebriller frem og intaster addressen forsigtigt.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du blev smækket over hovedet indtil du følte fugle flyve rundt om dit hoved! \n" +
                "Du følte dig pinligt berørt og da du tjekkede dine lommer havde du mistede din malerboutique kupon!! \n" +
                "Du løb tilbage til julglen grædende. \n" +
                "Du fortjener ikke at blive pink. \n" +
                "R.I.N.P, Game over.");
            gameOver();
        }
    }

    if (Choice == 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Du udforsker byen, og holder godt øje efter malerboutiquen, men du glemmer at kigge op! \n + " +
        "Et kæmpe klaver falder ned i hovedet på dig og du dør. \n" +
        "R.I.N.P, Game Over.");
        gameOver();
    }
}

void mall()
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine(
        "Du befinder dig nu i dette 'storcenter'.\n" +
        "Efter at kigge lidt rundt finder du endelig en skærm med et kort.\n" +
        "Men hvordan finder du malerboutiquen gennem dette kort?\n" +
        "1: Hack kortet \n" + "2: Giv op. \n" + "3: Tryk lidt på skærmen og håb for det bedste \n\n" +
        "");
    Console.Write("Hvad gør du: ");
    int Choice = int.Parse(Console.ReadLine());
    Console.Clear();

    if (Choice == 1)
    {
        Console.WriteLine("");
        mall();
    }

    if (Choice == 2)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Du giver op på din drøm. \n" +
            "Du vandrer tilbage til julglen og lever resten af dine dage uden at blive pink. \n" +
            "Du dør af tristhed og uden nogen venner, fordi du ikke blev pink og sej. \n" +
            "R.I.N.P, Game Over."); // R.I.N.P = Rest In Not Pink
        gameOver();
    }

    if (Choice == 3)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Du trykker vildt rundt på skærmen i håb på at finde malerboutiquen. \n" +
            "Du finder den ikke. \n" +
            "Du kommer også til at krasse skærmen lidt med dine skarpe klør, og lige pludslig virker skærmen ikke mere! \n" +
            "Til gengæld kommer der en vagt, der blev tilkaldt da signalet på en af skærmene blev stoppet \n" +
            "( og de mange klager om dig af de mange mennesker omkring dig. ) \n" +
            "Vagten gør klar til at fange dig!");
        //fight
    }
}

void gameOver()
{

}

void youWin()
{

}

bool Combat(Enemy enemy)
{
    string farlighed;

    while (true)
    {
        //advarer om næste enemy attack
        int enemyAttack = enemy.DoAttack();
        if (enemyAttack > 3)
        {
            farlighed = "meget";
        }
        else if (enemyAttack > 1)
        {
            farlighed = "medium";
        }
        else
        {
            farlighed = "lidt";
        }
        Console.WriteLine($"{enemy.name} ser {farlighed} farlig ud, du har {hp} hp.");

        //spillers tur
        Console.Write("1: Angrib \n2: Bloker\n" +
            "Hvad gør du: ");
        int input = int.Parse(Console.ReadLine());
        Console.Clear();
        if (input == 1)
        {
            //attack enemy
            enemy.currentHP -= attack;
            Console.WriteLine($"Du kradser {enemy.name} med dine mægtige panter klør og giver {attack} skade.");
        }
        else if (input == 2)
        {
            //bloker enemy
            enemyAttack = 0;
            Console.WriteLine($"Du gør klar til at blokere {enemy.name}s næste angreb.");
        }

        //er enemy død?
        if (enemy.currentHP <= 0)
        {
            return true;
        }

        //enemy turn
        hp -= enemyAttack;
        Console.WriteLine($"{enemy.name} hakker dig {farlighed} og giver {enemyAttack} skade.\n");

        //er du død?
        if (hp <= 0)
        {
            return false;
        }
    }
}