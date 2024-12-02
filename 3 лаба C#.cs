using System;
using System.Collections.Generic;

class WordFrequencyAnalyzer
{
    static void Main()
    {
        string inputText = "Hello world. Hello C#. C# is great. Hello World.";

        // Преобразование текста в нижний регистр и разделение на слова
        string[] splitWords = inputText.ToLower().Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

        // Словарь для подсчёта частоты слов
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (string word in splitWords)
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }

        // Вывод результата
        foreach (var entry in wordCounts)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}


//2 задание
/*
using System;
using System.Collections;
using System.Collections.Generic;

public class ResizableArray<T> : IEnumerable<T>
{
    private T[] _elements;
    private int _currentCount;

    public ResizableArray() : this(8) { }

    public ResizableArray(int initialCapacity)
    {
        _elements = new T[initialCapacity];
        _currentCount = 0;
    }

    public ResizableArray(IEnumerable<T> items)
    {
        _currentCount = 0;
        _elements = new T[8];  // Начальная инициализация

        foreach (var item in items)
        {
            Add(item);
        }
    }

    public int Count => _currentCount;
    public int Capacity => _elements.Length;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _currentCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _elements[index];
        }
        set
        {
            if (index < 0 || index >= _currentCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            _elements[index] = value;
        }
    }

    public void Add(T item)
    {
        ExpandCapacityIfNeeded(_currentCount + 1);
        _elements[_currentCount++] = item;
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public bool Remove(T item)
    {
        int index = Array.IndexOf(_elements, item, 0, _currentCount);
        if (index == -1)
            return false;

        for (int i = index; i < _currentCount - 1; i++)
        {
            _elements[i] = _elements[i + 1];
        }

        _currentCount--;
        _elements[_currentCount] = default(T);
        return true;
    }

    public bool Insert(int index, T item)
    {
        if (index < 0 || index > _currentCount)
            throw new ArgumentOutOfRangeException(nameof(index));

        ExpandCapacityIfNeeded(_currentCount + 1);

        for (int i = _currentCount; i > index; i--)
        {
            _elements[i] = _elements[i - 1];
        }

        _elements[index] = item;
        _currentCount++;
        return true;
    }

    private void ExpandCapacityIfNeeded(int minCapacity)
    {
        if (minCapacity > _elements.Length)
        {
            int newCapacity = _elements.Length == 0 ? 8 : _elements.Length * 2;
            Array.Resize(ref _elements, newCapacity);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _currentCount; i++)
        {
            yield return _elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}*/

//3 задание
/*
using System;
using System.Collections.Generic;

class CollectionExample
{
    static void Main()
    {
        // Список
        List<int> numberList = new List<int> { 1, 2, 3 };
        numberList.Add(4);
        numberList.Remove(2);

        // Словарь
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>();
        fruitDictionary["apple"] = 1;
        fruitDictionary["banana"] = 2;

        // Очередь
        Queue<string> stringQueue = new Queue<string>();
        stringQueue.Enqueue("first");
        stringQueue.Enqueue("second");
        string dequeuedElement = stringQueue.Dequeue();

        // Стек
        Stack<int> numberStack = new Stack<int>();
        numberStack.Push(10);
        numberStack.Push(20);
        int poppedElement = numberStack.Pop();
    }
}*/


/*
//4 задание
public class ComparableItem : IComparable<ComparableItem>
{
    public int DataValue { get; set; }

    public int CompareTo(ComparableItem other)
    {
        if (other == null) return 1;
        return this.DataValue.CompareTo(other.DataValue);
    }

    public override bool Equals(object obj)
    {
        if (obj is ComparableItem other)
            return this.DataValue == other.DataValue;

        return false;
    }

    public override int GetHashCode()
    {
        return DataValue.GetHashCode();
    }

    class EntryPoint
    {
        static void Main()
        {
            ComparableItem item1 = new ComparableItem { DataValue = 10 };
            ComparableItem item2 = new ComparableItem { DataValue = 20 };

            Console.WriteLine(item1.CompareTo(item2));  // -1, так как 10 < 20
        }
    }
}
*/