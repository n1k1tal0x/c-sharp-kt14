namespace App.Topics.LinkedList.T2b_DoubleLinkedList;

public class DoubleLinkedList<T>
{
    public T Value { get; }
    public DoubleLinkedList<T>? Prev { get; private set; }
    public DoubleLinkedList<T>? Next { get; private set; }
    public DoubleLinkedList(T value)
    {
        Value = value;
    }
    public int Count
    {
        get
        {
            DoubleLinkedList<T> tmp = this;
            while (tmp.Prev != null)
            {
                tmp = tmp.Prev;
            }
            int count = 1;
            while (tmp.Next != null)
            {
                count++;
                tmp = tmp.Next;
            }
            return count;
        }
    }
    public void AddBefore(T value)
    {
        if (this.Prev == null)
        {
            this.Prev = new DoubleLinkedList<T>(value);
            this.Prev.Next = this;
        } else {
            DoubleLinkedList<T> tmp = this.Prev;
            this.Prev = new DoubleLinkedList<T>(value);
            this.Prev.Prev = tmp;
            this.Prev.Next = this;
        }
    }
    public void AddAfter(T value) {
        if (this.Next == null)
        {
            this.Next = new DoubleLinkedList<T>(value);
            this.Next.Prev = this;
        }
        else
        {
            DoubleLinkedList<T> tmp = this.Next;
            this.Next = new DoubleLinkedList<T>(value);
            this.Next.Next = tmp;
            this.Next.Prev = this;
        }
    }
    public void AddFirst(T value) {
        DoubleLinkedList<T> tmp = this;
        while (tmp.Prev != null) { tmp = tmp.Prev; }
        tmp.Prev = new DoubleLinkedList<T>(value);
        tmp.Prev.Next = tmp;
    }
    public void AddLast(T value) {
        DoubleLinkedList<T> tmp = this;
        while (tmp.Next != null) { tmp = tmp.Next; }
        tmp.Next = new DoubleLinkedList<T>(value);
        tmp.Next.Prev = tmp;
    }
    public T[] ToArray()
    {
        List<T> res = new List<T>();
        DoubleLinkedList<T> tmp = this;
        while (tmp.Prev != null)
        {
            tmp = tmp.Prev;
        }
        while (tmp.Next != null)
        {
            res.Add(tmp.Value);
            tmp = tmp.Next;
        }
        res.Add(tmp.Value);
        return res.ToArray();
    }
}