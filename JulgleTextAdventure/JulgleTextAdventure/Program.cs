//kortlink.dk/2vbzr﻿
using JulgleTextAdventure;
using System;
using System.Data;

float hp = 5;
float attack = 1;
int rejerspist = 0;

List<KeyItem> inventoryKeyItems = new List<KeyItem>();
List<Consumable> inventoryConsumableItems = new List<Consumable>();
void ShowStats()
{
    Console.WriteLine($"Hp: {hp} Atk: {attack}");
    Console.WriteLine("Vigtige objekter---");
    string inventoryString = string.Empty;
    for (int i = 0; i < inventoryKeyItems.Count; i++)
    {
        inventoryString += inventoryKeyItems[i].name + ", ";
    }
    Console.WriteLine(inventoryString);
    inventoryString = string.Empty;
    for (int i = 0; i < inventoryConsumableItems.Count; i++)
    {
        if (inventoryConsumableItems.Count <= 0)
        {
            inventoryString = "Tom";
        }
        else
        {
            inventoryString += inventoryConsumableItems[i].name + ", ";
        }
    }
    Console.WriteLine("Drikkevarer---");
    Console.WriteLine(inventoryString);
    Console.WriteLine();
}





// Green --> Julge 
// DarkYellow --> Byen
// Gray --> Mall
// DarkCyan --> Fight
// Red --> Game Over
// R.I.N.P = Rest In Not Pink 
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

        while (true)
        {
            //spillers tur
            Console.WriteLine($"{enemy.name} ser {farlighed} farlig ud");
            ShowStats();
            Console.WriteLine();
            Console.Write("1: Angrib \n2: Bloker\n3: Brug item\n" +
                "Hvad gør du?: ");
            int input = readChoice(new List<int> { 1, 2, 3 });
            Console.Clear();
            if (input == 1)
            {
                //attack enemy
                enemy.currentHP -= attack;
                Console.WriteLine($"Du kradser {enemy.name} med dine mægtige panter klør og giver {attack} skade.");
                break;
            }
            else if (input == 2)
            {
                //bloker enemy
                enemyAttack = 0;
                Console.WriteLine($"Du gør klar til at blokere {enemy.name}s næste angreb.");
                break;
            }
            else if (input == 3)
            {
                //Use consumable
                Console.WriteLine($"{enemy.name} ser {farlighed} farlig ud");
                ShowStats();

                Console.WriteLine("\n0 for tilbage\n1 for at bruge første drikkevare item\n2 for at bruge anden, osv.");


                List<int> validValues = new List<int>(); //set valid inventory inputs stufs
                validValues.Clear();
                if (inventoryConsumableItems.Count == 0)
                {
                    validValues.Add(0);
                }
                else
                {
                    validValues.Add(0);
                    for (int i = 1; i <= inventoryConsumableItems.Count; i++)
                    {
                        validValues.Add(i);
                    }
                }


                input = readChoice(validValues);
                if (input == 0)
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    bool validItem = false;
                    for (int i = 0; i < input; i++)
                    {
                        if (i == input - 1)
                        {
                            if (inventoryConsumableItems[i].type.HasFlag(ItemTypes.Healing))
                            {
                                hp += inventoryConsumableItems[i].UseItem();
                            }
                            if (inventoryConsumableItems[i].type.HasFlag(ItemTypes.AttackIncrease))
                            {
                                attack += inventoryConsumableItems[i].UseItem();
                            }
                            inventoryConsumableItems.RemoveAt(i);
                        }
                    }
                    Console.Clear();
                }
            }
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

int readChoice(List<int> validInput)
{
    while (true)
    {
        string input = Console.ReadLine();
        int choice;
        if (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Det er ikke validt input. Prøv igen.");
            continue;
        }

        bool isValid = false;
        foreach (int i in validInput)
        {
            if (choice == i)
            {
                isValid = true;
                break;
            }
        }

        if (!isValid)
        {
            Console.WriteLine("Det er ikke validt input. Prøv igen.");
            continue;
        }
        else
        {
            return choice;
        }

    }
}



Main();
void Main()
{
    Console.ForegroundColor = ConsoleColor.White;
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
<<<<<<< HEAD
    int hp = 5;
    int attack = 1;
    int rejerspist = 0;
    inventoryConsumableItems.Clear();
    inventoryKeyItems.Clear();
=======
    hp = 5;
    attack = 1;
    rejerspist = 0;
>>>>>>> 618d92dbb42007273645962acc7afcc4f097d8e0
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
    inventoryKeyItems.Add(new KeyItem("La Malerboutique el Kupoña", ""));
    Console.Write("Hvad gør du?: ");
    int Choice = readChoice(new List<int> { 1, 2 });
    Console.Clear();

    if (Choice == 1 || Choice == 2) //Hej Håkon!!!!!!
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
        "1: Find et kort \n" + "2: Spørg den søde dame \n" + "3: Udforsk \n\n" );
    Console.Write("Hvad gør du?: ");
    int Choice = readChoice(new List<int> { 1, 2, 3 });
    Console.Clear();

    if (Choice == 1)
    {
        Console.WriteLine("Du leder desperat efter et kort, og du vandre ind i en kæmpe bygning kaldt 'storcenter'");
        mall();
        Console.Clear();
    }

    if (Choice == 2)
    {
        Console.WriteLine("Du spørger den søde dame om vej til malerboutiquen. \n" +
            "Damen skriger og gør klar til at slå dig med sin taske! \n");
        Enemy SødDame = new Enemy("Sød Dame", 3, 1);
        if (Combat(SødDame))
        {
            Console.WriteLine("Du absolut destruerer den stakkels dame. \n" +
                "Du stjal også hendes læbestift\n" +
                "Du finder dog en lille skærm på jorden ved siden af hende. \n" +
                "Når du samler den op er den allerede inde på et mini kort! Wow! \n" +
                "Du finder din kupon og dine læsebriller frem og indtaster addressen forsigtigt. \n" +
                "Du finder malerboutiquen, og begynder din rute.\n");
            inventoryConsumableItems.Add(new Consumable("Læbestift", "", ItemTypes.Healing));
            Console.WriteLine("Tryk 'Enter' for at fortsætte.");
            Console.ReadLine();
            Console.Clear();
            julglen();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du bliver smækket over hovedet indtil du føler fugle flyve rundt om dit hoved! \n" +
                "Du føler dig pinligt berørt og når du tjekker dine lommer har du mistet din malerboutique kupon!! \n" +
                "Du løber tilbage til julglen grædende. \n" +
                "Du fortjener ikke at blive pink. \n" +
                "R.I.N.P, Game over.");
            gameOver();
        }
    }

    if (Choice == 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Du udforsker byen, og holder godt øje efter malerboutiquen, men du glemmer at kigge op! \n" +
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
        "1: Hack kortet \n" + "2: Giv op \n" + "3: Tryk lidt på skærmen og håb for det bedste \n\n");
    Console.Write("Hvad gør du?: ");
    int Choice = readChoice(new List<int> { 1, 2, 3 });
    Console.Clear();

    if (Choice == 1)
    {
        Console.WriteLine(
             "Du hacker dig ind i mainframet.\n" +
             "Selv om du har ingen ide om hvad du lige gjorde. Du er inde. \n" +
             "På en eller anden måde finder du lokationen af malerboutiquen, som befinder sig i en lille landsby.. \n" +
             "1O meter fra julglen. Nå. Du er nød til at backtrack. \n" +
             "I det mindste ved du hvor malerboutiquen befinder sig nu. \n");
        Console.WriteLine("Tryk 'Enter' for at fortsætte.");
        Console.ReadLine();
        Console.Clear();
        julglen();
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
            "Vagten gør klar til at fange dig! \n");

        Enemy Vagt = new Enemy("Vagt", 5, 1);
        if (Combat(Vagt))
        {
            Console.WriteLine("Du hakker ham i stykker, han dør. \n" + 
                "Du stjæler hans firkantet tale ting, den laver en kradsende lyd og du høre en stemme komme igennem. \n" + 
                "'Paul kom ind. Kan du høre os?.'\n" + 
                "Du prøver pænt at kommunikere at du ikke er Paul og at du bare gerne vil hen til malerboutiquen, men det lyder som altid lidt groft.\n" + 
                "'RAHHHH rah rah' \n" +
                "'Paul vi har snakket om de der dyrelyde, men det er modtaget. Malerbotiquen ligger i en lille landsby ikke så langt fra julglen, du ved, der ved siden af Johnny. Du er dog blevet bedre til dyrelydene, har du øvet dig siden sidst? Nå men, Hold os opdateret Paul. '\n");
            Console.WriteLine("Tryk 'Enter' for at fortsætte.");
            inventoryKeyItems.Add(new KeyItem("Walkie talkie", ""));
            Console.ReadLine();
            Console.Clear();
            julglen();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Av av av. Du fik lidt tæv. \n" + 
                "Vagten tager din næsten bevidstløse form og det ligner han laver et opkald på hans firkantet tale ting. Du hører lidt af samtalen. \n" + 
                "'Rasmus jeg lyver ikke! Jeg har en bedvidstløs panther i storcenteret! uh huh..' \n" + 
                "'Nej, jeg lavede ikke en panther lyd Rasmus, jeg slog den bevidstløs.. Ja, ja virkelig.' \n" + 
                "'Zoo? Ja det lyder da som en god ide.. Rasmus kan du ikke sådan, ringe til nogen for at hjælpe mig.. Okay.. Så må jeg vente..' \n" +
                "Du besvimmede og vågnede kort efter da vagten skulle aflevere dig til nogen med meget grej. Vagten begynder at langsomt svæve op ad.. ??\n" + 
                "'Tak for hjælpen.. Jeg har fundet mig selv nu.. Jeg hedder Paullllll. Med et L..' \n" + 
                "Du har ingen ide om hvad kigger på lige nu. Du besvimer igen og vågner op i en zoo. Du bliver nu aldrig pink. R.I.N.P. \n");
            gameOver();
        }

    }
}

void julglen()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
        "Du vandrer gennem julglen, og tager vejen langs floden, den minder dig næsten om den dag.\n" +
        "Det var en hård dag for alle, men mest dig. \n" +
        "Ingen vil nogensinde forstå det som du gjorde.\n" +
        "Det er ikke din skyld at alle andre siger du overdriver, du ved hvad der virkelig skete den dag.\n" +
        "Du er en super sej panter, du fortjener at blive pink.\n" +
        "Anyways. Du er befinder dig nu i den lille landsby.\n");
    Console.WriteLine("Tryk 'Enter' for at fortsætte.");
    Console.ReadLine();
    Console.Clear();
    lilleLandsby();
}

void lilleLandsby()
{
    Console.ForegroundColor = ConsoleColor.Green;
    int rejerspist = 0;
    Console.WriteLine(
        "Du vandrer ind i den lille landsby og kigger rundt.\n" +
        "Det er en meget smuk landsby, det må du indrømme. \n" +
        "Du går direkte hen til malerboutiquen og prøver at åbne døren, men den rykker sig ikke.\n" +
        "Du tager et skridt tilbage og kigger rundt, og finder et stykke paper på døren...\n" +
        "Malerboutiquen åbner først om omkring en time.\n" +
        "Du har stadig lidt tid at spilde.\n" +
         "1: Gå ind i en rejebutik \n" + "2: Gå lidt rundt \n" + "3: Tag en lur \n\n");
    Console.Write("Hvad gør du?: ");
    int Choice = readChoice(new List<int> { 1, 2, 3 });
    Console.Clear();

    if (Choice == 1)
    {
        rejebutik();
    }

    if (Choice == 2)
    {
        //Kæmp mod bil
        Console.WriteLine("Du går lidt rundt og pludselig finder du dig selv i midten af en motorvej. \n" +
            "Heldigvis er der kun en bil på vejen. \n" +
            "... \n" +
            "Bilen kører efter dig. \n" +
            "Den har onde øjne.");
        Console.WriteLine("Tryk 'Enter' for at fortsætte.");
        Console.ReadLine();
        Console.Clear();
        Enemy Bil = new Enemy("Bil", 4, 2);
        if (Combat(Bil))
        {
            Console.WriteLine("Du flænser bilen i småstykker med dine skarpe klør. \n" +
                "Det er ret sejt. \n" +
                "Lidt som en actionfilm. \n" +
                "Du føler dig som wolverine.");
                Console.WriteLine("Tryk 'Enter' for at fortsætte.");
                Console.ReadLine();
                Console.Clear();
                lilleLandsby();
        }
        else
        {
            Console.WriteLine("Efter en hård kamp kører bilen dig ned og du dør. \n" +
                "Du kommer aldrig til at blive pink.");
            gameOver();
        }
    }

    if (Choice == 3)
    {
        //lur
        Console.WriteLine("Du ligger dig ned for at tage en dejlig afslappende lur, og du når lige at falde i søvn inden du igen pludseligt bliver vækket. \n" +
            "Nogen træder hårdt på din endnu ikke pinke hale, og du springer 51 meter op luften. \n" +
            "Når du endelig lander få meter fra hvor du sov ser du hende. \n" +
            "Chantel Dubois. \n" +
            "'Det er mig, Chantel Dubois,' siger hun. \n" +
            "'Vidste du, at hp står for Hasty Hag Percentages?' \n" +
            "Hun sprinter efter dig i fuld fart.");
        Console.WriteLine("Tryk 'Enter' for at fortsætte.");
        Console.ReadLine();
        Console.Clear();
        //chantel
        Enemy Chantel = new Enemy("Chantel Dubois", 1000000, 1);
        if (Combat(Chantel))
        {
            Console.WriteLine("Du besejrede Chantel Dubois. Hvordan. Dette er umuligt. Du har vundet");
            youWin();
        }
        else
        {
            Console.WriteLine("Efter en tapper, men uvindelig kamp bliver du endlig dræbt af Chantel Dubois. \n" +
                "Det er ikke noget mysterie, det er trods alt hendes speciale at fange julgle dyr. \n" +
                "Du kommer aldrig til at blive pink.");
            gameOver();
        }
    }
}

void rejebutik()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
        "Du finder dig i rejebutikken, fedt.\n" +
        "Der er én slags reje.\n" +
        "1: Spis reje \n" + "2: Gå \n");
    Console.Write("Vil du spise?: ");
    int Choice = readChoice(new List<int> { 1, 2 });
    Console.Clear();
    if (Choice == 1)
    {
        //kæmp mod reje 
        Enemy Reje = new Enemy("Reje", 1, 0);
        if (Combat(Reje))
        {
            Console.WriteLine("Du æder en reje");
            rejerspist += 1;
            if (rejerspist == 30)
            {
                rejeWin();
            }
            else
            {
                Console.WriteLine("Tryk 'Enter' for at fortsætte.");
                Console.ReadLine();
                Console.Clear();
                rejebutik();
            }    
        }
    }

    if (Choice == 2)
    {
        Console.WriteLine("Okay, du går ud igen..");
        lilleLandsby();
    }

}

void rejeWin()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Du har spist sååååå mange rejer og du har liiidt ondt i maven. \n" +
        "Du er proppet fuld af et eller andet stof i rejerne, nok det der gør dem pink, og også det der gør flamingoer pink." +
        "Derfor er du også blevet pink. fucking episk");
    youWin();
}

void gameOver()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n Tryk på 'enter' for at prøve igen...");
    Console.ReadLine();
    Console.Clear();
    Main();
}

void youWin()
{

}