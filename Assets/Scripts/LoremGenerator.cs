// Joshua Chisholm
// 10/4/24
// Generates random words for lorem ipsum
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoremGenerator : MonoBehaviour
{
    // String to contain the lorem language
    private string lorem;

    // Array to store lorem words
    private string[] words;
    // Start is called before the first frame update

    void Start()
    {
        // Set up lorem and split
        lorem = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Et error, ullam illo expedita sapiente totam repellat, temporibus corrupti ipsa dolorem esse, nostrum dolorum quisquam iure? Iusto maxime, " +
             "iste laborum amet ipsa quod nisi ducimus incidunt dolor porro velit modi praesentium quisquam, in eius dicta ipsam aut officia dolore facere placeat repellendus? Voluptatum ipsum omnis quos sed, excepturi ad eaque assumenda. " +
             "Illo, ipsum! Voluptate quidem numquam blanditiis repellat fuga quia provident distinctio, vel fugiat culpa voluptatibus quod dolore, " +
             "tenetur totam similique eligendi in? Eum nobis officia tenetur in quas deleniti inventore obcaecati cum quidem possimus. Rerum tempora quas at neque eveniet.";
        words = lorem.Split(' ');
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetAWord());
    }

    /// <summary>
    /// Return a random lorem word
    /// </summary>
    /// <returns></returns>
    public string GetAWord()
    {
        return words[(int)Random.Range(0, words.Length)];
    }
}
