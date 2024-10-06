using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Options
{
    Genre,
    Hero,
    Villain,
    Sidekick,
    Setting,
    Plot
}

public static class Storage
{
    public const float MAX_NOSTALGIA = 5f;

    static Choice[] genres =
    {
        new Choice("Action"),
        new Choice("Thriller"),
        new Choice("Horror"),
        new Choice("Romance"),
        new Choice("Comedy"),
        new Choice("Romantic Comedy"),
        new Choice("Drama"),
        new Choice("Documentary"),
        new Choice("Western"),
        new Choice("Fantasy"),
        new Choice("Mystery"),
        new Choice("Musical")
    };

    static Choice[] heroes =
    {
        new Choice("Sir Gonealot"),
        new Choice("Ohio John"),
        new Choice("The Rectangle"),
        new Choice("RITchie"),
        new Choice("Clyde"),
        new Choice("The Player"),
        new Choice("Lora Craft"),
        new Choice("A Bowling Ball"),
        new Choice("Horace the Hippo"),
        new Choice("Lebanon Jakes"),
        new Choice("Beefilton")
    };

    static Choice[] villains =
    {
        new Choice("The Giggler"),
        new Choice("Dork Wader"),
        new Choice("The Evil Lizard Wizard"),
        new Choice("Captain Moby"),
        new Choice("Pineconehead"),
        new Choice("Sansa"),
        new Choice("Mousewoman"),
        new Choice("The Hanging Tree"),
        new Choice("Doug"),
        new Choice("George Orwell"),
        new Choice("Copyright Infringement"),
        new Choice("Monster of the Week")
    };

    static Choice[] sidekicks =
    {
        new Choice("Sir Squire, Esquire"),
        new Choice("Timmy"),
        new Choice("Gloves the Giraffe"),
        new Choice("Giant the Giant Dragon"),
        new Choice("A Djinni"),
        new Choice("George Washington"),
        new Choice("Imeno"),
        new Choice("Sans Cooperative"),
        new Choice("Helvetica"),
        new Choice("Joe Purpleman"),
        new Choice("Fred Cashvalue"),
        new Choice("Fitzgerald")
    };

    static Choice[] settings =
    {
        new Choice("The City"),
        new Choice("The Jungle"),
        new Choice("The Underworld"),
        new Choice("The 96.48 Acre Woods"),
        new Choice("In Space!"),
        new Choice("In Another Universe"),
        new Choice("Underground"),
        new Choice("Office Building"),
        new Choice("On the Sea"),
        new Choice("In Limbo"),
        new Choice("Cozy Neighborhood"),
        new Choice("Salem Witch Trials"),
        new Choice("Abandoned Movie Theater")
    };

    static Choice[] plots =
    {
        new Choice("High Speed Chase"),
        new Choice("A MacGuffin"),
        new Choice("Romantic Affair"),
        new Choice("A Series of Misfortunes"),
        new Choice("Finding a Long-Lost Twin"),
        new Choice("Dodging Deadly Traps"),
        new Choice("One Last Chance at Love"),
        new Choice("Constant Power Struggles"),
        new Choice("Distant Flashbacks"),
        new Choice("A Holdup"),
        new Choice("A New World Expedition")
    };

    public static Choice[] GetOptions(Options option)
    {
        switch (option) {
            case Options.Genre: return GetOptions(genres);
            case Options.Hero: return GetOptions(heroes);
            case Options.Villain: return GetOptions(villains);
            case Options.Sidekick: return GetOptions(sidekicks);
            case Options.Setting: return GetOptions(settings);
            case Options.Plot: return GetOptions(plots);
            default: return null;
        }
    }

    static Choice[] GetOptions(Choice[] options)
    {
        string[] selected = new string[2];
        int firstRand = WeightedRandom(options);
        int secondRand;

        while ((secondRand = WeightedRandom(options)) == firstRand);

        return Random.Range(0, 2) == 0 ?
            new Choice[] { options[firstRand], options[secondRand] } :
            new Choice[] { options[secondRand], options[firstRand] };
    }

    /// <summary>
    /// Picks a random Choice weighted on how often they've been picked before
    /// </summary>
    /// <param name="options">Array of choices</param>
    /// <returns>The index of the item it chose</returns>
    static int WeightedRandom(Choice[] options)
    {
        int total = 0;
        foreach (Choice c in options) {
            total += c.Count;
        }

        int rand = Random.Range(0, total);

        total = 0;
        for (int i = 0; i < options.Length; i++) {
            total += options[i].Count;
            if (rand < total)
                return i;
        }

        return options.Length - 1;
    }

    public static int GetApproval(Choice[] options)
    {
        float max = MAX_NOSTALGIA * options.Length;
        float total = 0;
        foreach (Choice c in options) {
            total += c.Nostalgia;
        }
        return (int)(Mathf.Sqrt((total / max * 100))*10);
    }
}

public class Choice
{
    string title;
    int count;
    float nostalgia;

    public string Title { get { return title; } }
    public int Count { get { return count; } }
    public float Nostalgia { get { return nostalgia; } }

    public Choice(string title)
    {
        this.title = title;
        count = 1;
        nostalgia = Random.Range(.5f,2f);
    }

    public void Picked()
    {
        if (count > 2)
            nostalgia -= Random.Range(0.25f, 1f);
        else if(count == 2)
            nostalgia = Storage.MAX_NOSTALGIA;
        
        count++;

    }
    public void NotPicked()
    {
        if (count > 1)
            nostalgia += Random.Range(0f, 0.5f);
    }
}