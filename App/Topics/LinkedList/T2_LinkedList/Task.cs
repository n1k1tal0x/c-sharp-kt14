namespace App.Topics.LinkedList.T2_LinkedList;

public static class LinkedListTasks
{
    public static System.Collections.Generic.LinkedList<int> RemoveDuplicates(System.Collections.Generic.LinkedList<int> list)
    {
        if (list == null ) { throw new ArgumentNullException(); }
        LinkedList<int> res = new LinkedList<int>();
        HashSet<int> exist = new HashSet<int>();

        foreach (var item in list)
        {
            if (exist.Add(item)) { res.AddLast(item); }
        }
        return res;
    }
}