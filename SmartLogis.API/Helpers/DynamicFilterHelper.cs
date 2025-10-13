using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SmartLogis.API.Models;
using System.Linq.Dynamic.Core;
// using Newtonsoft.Json;
using System.Text.Json;

namespace SmartLogis.API.Helpers;
public static class DynamicFilterHelper
{
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, Dictionary<string, Filter> filters)
    {
        foreach (var filter in filters)
        {
            string propertyName = filter.Key;
            var f = filter.Value;

            if (f == null) continue;
            object? eq       = ConvertJsonElement(f.Eq);
            object? ne       = ConvertJsonElement(f.Ne);
            object? gt       = ConvertJsonElement(f.Gt);
            object? lt       = ConvertJsonElement(f.Lt);
            object? gte      = ConvertJsonElement(f.Gte);
            object? lte      = ConvertJsonElement(f.Lte);
            object? contains = ConvertJsonElement(f.Contains);
            var inList = ConvertJsonElement(f.In) as IEnumerable<object>;

            if (eq != null)
            {
                query = query.Where($"{propertyName} = @0", eq);
            }
            if (ne != null)
            {
                query = query.Where($"{propertyName} != @0", ne);
            }
            if (gt != null)
            {
                query = query.Where($"{propertyName} > @0", gt);
            }
            if (lt != null)
            {
                query = query.Where($"{propertyName} < @0", lt);
            }
            if (gte != null)
            {
                query = query.Where($"{propertyName} >= @0", gte);
            }
            if (lte != null)
            {
                query = query.Where($"{propertyName} <= @0", lte);
            }
            if (contains != null)
            {
                query = query.Where($"{propertyName}.Contains(@0)", contains);
            }
            if (inList != null && inList.Any())
            {
                var propType = typeof(T).GetProperty(propertyName,
                    System.Reflection.BindingFlags.IgnoreCase |
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Instance
                )?.PropertyType;
                var typedList = Array.CreateInstance(propType!, inList.Count());
                int index = 0;
                foreach(var item in inList)
                {
                    typedList.SetValue(Convert.ChangeType(item, propType!), index++);
                }
                query = query.Where($"@0.Contains({propertyName})", typedList);
            }

        }
        return query;
    }

    static dynamic? ConvertJsonElement(object value)
    {
        if (value == null) return null;

        if (value is JsonElement je)
        {
            switch (je.ValueKind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return null;
                case JsonValueKind.String:
                    // Intentamos convertir string a DateTime o Guid si aplica
                    if (DateTime.TryParse(je.GetString(), out var dateVal))
                        return dateVal;
                    if (Guid.TryParse(je.GetString(), out var guidVal))
                        return guidVal;
                    return je.GetString();
                case JsonValueKind.Number:
                    if (je.TryGetInt64(out long l)) return l;
                    if (je.TryGetDouble(out double d)) return d;
                    return je.GetDecimal();

                case JsonValueKind.True:
                case JsonValueKind.False:
                    return je.GetBoolean();

                case JsonValueKind.Array:
                    return je.EnumerateArray()
                                .Select(x => ConvertJsonElement(x)) // 👈 Recursivo, respeta tipos
                                .ToList();

                case JsonValueKind.Object:
                    // Deserializamos a Dictionary<string,object>
                    return JsonSerializer.Deserialize<Dictionary<string, object>>(je.GetRawText());
            }
        }
        return null;
    }
}