﻿using System.Collections;
using System.Text.Json;

namespace HundredMSRest.Lib.Core.Requests;

/// <summary>
/// List of RequestRecords
/// </summary>
/// <typeparam name="T"></typeparam>
public record RequestRecordList<T> : RequestRecord, IList<T>
{
    private readonly List<T> _list = new List<T>();

    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    public int Count => _list.Count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return _list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
    }

    public bool Remove(T item)
    {
        return _list.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    public override string GetJSON()
    {
        return JsonSerializer.Serialize(_list, _list.GetType(), RecordSerializerOptions);
    }
}
