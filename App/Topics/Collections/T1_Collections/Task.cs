using System.Collections;

namespace App.Topics.Collections.T1_Collections;
public static class CollectionsTasks
{
    public static System.Collections.ArrayList FilterUniqueStringsNonGeneric(System.Collections.IEnumerable source)
    {

        System.Collections.ArrayList res = new System.Collections.ArrayList();
        System.Collections.ArrayList exist = new System.Collections.ArrayList();
        foreach (var item in source)
        {
            if (item is string)
            {
                if (item.ToString().Trim() != "")
                {
                    if (!exist.Contains(item.ToString().Trim().ToLower()))
                    {
                        res.Add(item.ToString().Trim());
                        exist.Add(item.ToString().Trim().ToLower());
                    }
                }
            }
        }
        return res;
    }
    public static System.Collections.Generic.List<string> FilterUniqueStringsGeneric(System.Collections.Generic.IEnumerable<string> source)
    {
        System.Collections.Generic.List<string> res = new System.Collections.Generic.List<string> ();
        System.Collections.Generic.List<string> exist = new System.Collections.Generic.List<string>();
        foreach (var item in source)
        {
            if (item != null && item.ToString().Trim() != "")
            {
                if (!exist.Contains(item.ToString().Trim().ToLower()))
                {
                    res.Add(item.ToString().Trim());
                    exist.Add(item.ToString().Trim().ToLower());
                }
            }
        }
        return res;
    }
}