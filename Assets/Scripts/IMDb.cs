using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class IMDb
{
    string title;
    int iteration;
    
    string[] suffixes =
    {
        "In Space!",
        "Bigger and Better",
        "The Final Hour",
        "Endgame",
        "World War",
        "Nevermore",
        "Cash Grab",
        "Curse of the Thingamabob",
        "Unleashed",
        "The Revenge",
        "Apocalypse",
        "Mission Improbable",
        "Oops, All Sequels!",
        "Now in 3D!",
        "Definitive Edition",
        "The Snyder Cut",
        "Tokyo Drift",
        "The Quantum Dimension",
        "The Christmas Special",
        "Back In Time",
        "The Finale (Part 1)",
        "CGI Mayhem",
        "Back To Basics",
        "Halloween Night",
        "Calm Before The Storm",
        "Seafarers",
        "The Tax Write-Off",
        "The Musical",
        "The Musical: The Movie",
        "Lost in New Jersey",
        "This Is A Call For Help",
        "NullReferenceException",
        "The Reimagining",
        "V3",
        "The Suffix!",
        "Feat. Clyde",
        "Unholy",
        "Is This Enough?"
    };

    public IMDb(string title)
    {
        this.title = title;
        iteration = 1;
    }
    
    public string NewTitle()
    {
        switch (++iteration) {
            case 1: return title;
            case 2: return title + " " + iteration;
            default: return title + " " + iteration + 
                    (Random.Range(0, 2) == 0 ? ": " + 
                    suffixes[Random.Range(0, suffixes.Length)] : "");
        }
    }
}