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

public class Storage : MonoBehaviour
{
    Choice[] genres =
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

    Choice[] heroes =
    {
        new Choice("Sir Gonealot"),
        new Choice("Ohio John"),
        new Choice("The Rectangle"),
        new Choice("Rochester Reggie"),
        new Choice("Clyde"),
        new Choice("The Player"),
        new Choice("Lora Craft"),
        new Choice("A Bowling Ball"),
        new Choice("Horace the Hippo"),
        new Choice("Beefilton"),
    };

    Choice[] villains =
    {
        new Choice("The Laugher"),
        new Choice("Dork Wader"),
        new Choice("The Evil Lizard Wizard of the South"),
        new Choice("Captain Moby"),
        new Choice("Pineconehead"),
        new Choice("Sansa"),
        new Choice("Mousewoman"),
        new Choice("The Hanging Tree"),
        new Choice("Doug"),
        new Choice("Monster of the Week"),
    };

    Choice[] sidekicks =
    {
        new Choice("Sir Squire, Esquire"),
        new Choice("Timmy"),
        new Choice("Gloves the Giraffe"),
        new Choice("Giant the Giant Dragon"),
        new Choice("A Djinni"),
        new Choice("George Washington"),
        new Choice("Imeno"),
        new Choice("Sans Cooperative"),
        new Choice("Joe Purpleman"),
        new Choice("Fred Cashvalue"),
    };

    Choice[] settings =
    {
        new Choice("The City"),
        new Choice("The Jungle"),
        new Choice("In Space!"),
        new Choice("In Another Universe..."),
        new Choice("Underground"),
        new Choice("In an Office Building"),
        new Choice("On the Sea"),
        new Choice("In Limbo"),
        new Choice("A Cozy Neighborhood"),
        new Choice("In an Abandoned Movie Theater"),
    };

    Choice[] plots =
    {
        new Choice("High Speed Chase"),
        new Choice("A Macguffin"),
        new Choice("Romantic Affair"),
        new Choice("A Series of Miscommunications"),
        new Choice("Deadly Traps & Daring Escapades"),
        new Choice("One Last Chance at Love"),
        new Choice("A Town Too Small for the Two of Them"),
        new Choice("What happened Last Summer?"),
        new Choice("A Holdup"),
        new Choice("An Expedition to somewhere new..."),
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Choice[] GetOptions(Options option)
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

    Choice[] GetOptions(Choice[] options)
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
    int WeightedRandom(Choice[] options)
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
        nostalgia = 0.25f;
    }

    public void Picked()
    {
        if (count > 1)
            nostalgia -= Random.Range(0.25f, 0.5f);
        else
            nostalgia = 5f;
        
        count++;

    }
    public void NotPicked()
    {
        nostalgia += Random.Range(0f, 0.25f);
    }
}