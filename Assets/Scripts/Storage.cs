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
        
    };

    Choice[] villains =
    {
        
    };

    Choice[] sidekicks =
    {
        
    };

    Choice[] settings =
    {
        
    };

    Choice[] plots =
    {
        
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Choice[] test = GetOptions(Options.Genre);
        Debug.Log(test[0].Title + ", " + test[1].Title);
        genres[0].Picked();
    }

    public Choice[] GetOptions(Options option)
    {
        switch (option)
        {
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

    public string Title { get { return title; } }
    public int Count { get { return count; } }

    public Choice(string title)
    {
        this.title = title;
        count = 1;
    }

    public void Picked()
    {
        count++;
    }
}