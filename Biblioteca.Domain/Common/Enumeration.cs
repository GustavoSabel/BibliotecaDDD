﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Biblioteca.Domain.Common
{
    public abstract class Enumeration : IComparable<Enumeration>
    {
        protected Enumeration()
        {
            Value = 0;
            DisplayName = "";
        }

        protected Enumeration(int value, string displayName)
        {
            Value = value;
            DisplayName = displayName;
        }

        public int Value { get; }

        public string DisplayName { get; }

        public override string ToString() => DisplayName;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Enumeration otherValue))
                return false;

            var typeMatches = GetType().Equals(obj?.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => HashCode.Combine(Value);

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(Enumeration? other)
        {
            return Value.CompareTo(other?.Value);
        }
    }
}
