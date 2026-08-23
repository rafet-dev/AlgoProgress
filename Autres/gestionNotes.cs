using System.ComponentModel;
double nombreNotes;
double iNote;
double i = 0;
double [] notes;
double moyenne = 0;
int auDessus = 0;

double NombreAsaisir()
{
    Console.WriteLine("Combien de notes voulez-vous saisir ? ");
    string nbnotesStr = Console.ReadLine();
    while (!double.TryParse(nbnotesStr, out nombreNotes))
    {
        Console.WriteLine("Combien de notes voulez-vous saisir ? ");
        nbnotesStr = Console.ReadLine();
    }
    return nombreNotes;
}

double LireNote()
{ 
    Console.WriteLine("Saisissez la note " + (i + 1) + " :");
    string iNoteStr = Console.ReadLine();
    while (!double.TryParse(iNoteStr, out iNote) || iNote < 0 || iNote > 20)
    {
        Console.WriteLine("Resaisir la note ? ");
        iNoteStr = Console.ReadLine();
    }  
    i++;

    return iNote;
}

double[] SaisirNotes(double nombreNotes)
{
    notes = new double[(int)nombreNotes];
    for (int l = 0; l < notes.Length ; l++)
    {
        notes[l] = LireNote();
    }
    return notes;
}

double CalculerMax(double[] notes)
{
    double max = notes[0];
    for (int j = 0; j < notes.Length; j++)
    {
        if (notes[j] > max)
        {
            max = notes[j];
        }
    }
    return max;
}

double CalculerMin(double[] notes)
{
    double min = notes[0];
    for (int k = 0 ; k < notes.Length ; k++)
    {
        if (notes[k] < min)
        {
            min = notes[k];
        }
    }
    return min;
}

void AfficherNotes(double[] notes)
{
    for (int m = 0; m < notes.Length ; m++)
    {
        Console.WriteLine("Note n° " + (m + 1) + " : " + notes[m]);
    }
}

double CalculerMoyenne(double[] notes)
{
    double somme = 0;

    for (int n = 0; n < notes.Length; n++)
    {
        somme += notes[n];
    }

    moyenne = somme/notes.Length;
    return moyenne;
}

string ObtenirMention(double moyenne)
{
    if (moyenne >= 16)
    {
        return "Mention Très Bien !!!";
    }
    else if (moyenne >= 14)
    {
        return "Mention Bien !!";
    }
    else if (moyenne >= 12)
    {
        return "Mention Assez Bien !";
    }
    else if (moyenne >= 10)
    {
        return "Mention Passable";
    }
    else
    {
        return "Insuffisant ...";
    }
}

double CompterNotesAuDessusMoyenne (double [] notes)
{
    moyenne = CalculerMoyenne(notes);
    for (int o = 0; o < notes.Length; o++)
    {
        if (notes[o] > moyenne)
        {
            auDessus++;
        }
    }

    return auDessus;
}

void AfficherStatistiques(double [] notes)
{
    Console.WriteLine("Statistiques :");
    Console.WriteLine("Note minimale : " + CalculerMin(notes));
    Console.WriteLine("Note maximale : " + CalculerMax(notes));
    Console.WriteLine("Nombre de notes au dessus de la moyenne : " + CompterNotesAuDessusMoyenne(notes));
    Console.WriteLine("Moyenne : " + CalculerMoyenne(notes));
    Console.WriteLine(ObtenirMention(moyenne));
}

NombreAsaisir();
SaisirNotes(nombreNotes);
Console.WriteLine("\n");
AfficherNotes(notes);
Console.WriteLine("\n");
AfficherStatistiques(notes);

