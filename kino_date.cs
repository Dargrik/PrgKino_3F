using System;

class Program
{
    static void Main()
    {
        string zacatek1Str = Console.ReadLine();
        string[] delka1Pole = Console.ReadLine().Split(' ');
        string zacatek2Str = Console.ReadLine();
        string[] delka2Pole = Console.ReadLine().Split(' ');

        // Přístup 1: Přímý převod času na minuty od půlnoci
        // ------------------------------------------------------------
        int zacatek1 = PrevedCasNaMinuty(zacatek1Str);
        int delka1 = int.Parse(delka1Pole[0]) * 60 + int.Parse(delka1Pole[1]);
        int zacatek2 = PrevedCasNaMinuty(zacatek2Str);
        int delka2 = int.Parse(delka2Pole[0]) * 60 + int.Parse(delka2Pole[1]);

        int konec1 = zacatek1 + delka1;
        int konec2 = zacatek2 + delka2;

        string konec1Vystup = PrevedMinutyNaCas(konec1 % 1440);
        string konec2Vystup = PrevedMinutyNaCas(konec2 % 1440);

        Console.WriteLine("//Řešení pomocí převodu času na minuty:");
        Console.WriteLine($"První film trvá {delka1} minut a skončí v {konec1Vystup}.");
        Console.WriteLine($"Druhý film trvá {delka2} minut a skončí v {konec2Vystup}.");

        int upravenyZacatek2 = zacatek2;
        if (zacatek2 < konec1)
            upravenyZacatek2 += 1440;
        int upravenyKonec2 = upravenyZacatek2 + delka2;

        if (konec1 <= upravenyZacatek2)
        {
            int cekaciDoba = upravenyZacatek2 - konec1;
            if (cekaciDoba > 0)
                Console.WriteLine($"\"Druhý film můžete stihnout včas s předstihem {cekaciDoba} minut.\"");
            else
                Console.WriteLine($"\"Druhý film můžete stihnout včas.\"");
        }
        else
        {
            if (konec1 >= upravenyKonec2)
            {
                Console.WriteLine("\"Druhý film nestihnete vůbec.\"");
            }
            else
            {
                int zmeskanyCas = konec1 - upravenyZacatek2;
                Console.WriteLine($"\"Nestihnete {zmeskanyCas} minut druhého filmu.\"");
            }
        }

        // Přístup 2: Přidání pevného posunu 9 hodin (540 minut)
        // ------------------------------------------------------------
        int casovyPosun = 540;

        int posunutyZacatek1 = (PrevedCasNaMinuty(zacatek1Str) + casovyPosun) % 1440;
        int posunutyZacatek2 = (PrevedCasNaMinuty(zacatek2Str) + casovyPosun) % 1440;

        int posunutyKonec1 = (posunutyZacatek1 + delka1) % 1440;
        int posunutyKonec2 = (posunutyZacatek2 + delka2) % 1440;

        string posunutyKonec1Vystup = PrevedMinutyNaCas((posunutyKonec1 - casovyPosun + 1440) % 1440);
        string posunutyKonec2Vystup = PrevedMinutyNaCas((posunutyKonec2 - casovyPosun + 1440) % 1440);

        Console.WriteLine("//Řešení pomocí posunu času:");
        Console.WriteLine($"První film trvá {delka1} minut a skončí v {posunutyKonec1Vystup}.");
        Console.WriteLine($"Druhý film trvá {delka2} minut a skončí v {posunutyKonec2Vystup}.");

        if (posunutyZacatek2 >= posunutyKonec1)
        {
            int cekaciDoba = posunutyZacatek2 - posunutyKonec1;
            Console.WriteLine(cekaciDoba > 0 
                ? $"Druhý film můžete stihnout včas s předstihem {cekaciDoba} minut." 
                : "Druhý film můžete stihnout včas.");
        }
        else
        {
            int zmeskanyCas = posunutyKonec1 - posunutyZacatek2;
            if (zmeskanyCas >= delka2)
            {
                Console.WriteLine("Druhý film nestihnete vůbec.");
            }
            else
            {
                Console.WriteLine($"Nestihnete {zmeskanyCas} minut druhého filmu.");
            }
        }
    }

    static int PrevedCasNaMinuty(string casStr)
    {
        string[] casti = casStr.Split(':');
        int h = int.Parse(casti[0]);
        int m = int.Parse(casti[1]);
        return h * 60 + m;
    }

    static string PrevedMinutyNaCas(int minuty)
    {
        minuty %= 1440;
        if (minuty < 0)
            minuty += 1440;
        int h = minuty / 60;
        int m = minuty % 60;
        return $"{h:D2}:{m:D2}";
    }
}
