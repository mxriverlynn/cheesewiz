using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace CheeseWiz.Specs.BDD
{
	public static class NUnitExtensions
	{
		public static void ShouldStartWith(this string text, string expected)
		{
			Assert.That(text.StartsWith(expected));
		}

		public static void ShouldStartWith(this string text, string expected, string message)
		{
			Assert.That(text.StartsWith(expected), message);
		}

		public static void ShouldEndWith(this string text, string expected)
		{
			Assert.That(text.EndsWith(expected));
		}

		public static void ShouldEndWith(this string text, string expected, string message)
		{
			Assert.That(text.EndsWith(expected), message);
		}

		public static void ShouldBeTrue(this bool condition)
		{
			Assert.That(condition, Is.True);
		}

		public static void ShouldBeTrue(this bool condition, string message)
		{
			Assert.That(condition, Is.True, message);
		}

		public static void ShouldBeFalse(this bool condition)
		{
			Assert.That(condition, Is.False);
		}

		public static void ShouldBeFalse(this bool condition, string message)
		{
			Assert.That(condition, Is.False, message);
		}

		public static void ShouldEqual(this object actual, object expected)
		{
			Assert.That(actual, Is.EqualTo(expected));
		}

		public static void ShouldEqual(this object actual, object expected, string message)
		{
			Assert.That(actual, Is.EqualTo(expected), message);
		}

		public static void ShouldNotEqual(this object actual, object expected)
		{
			Assert.That(actual, Is.Not.EqualTo(expected));
		}

		public static void ShouldNotEqual(this object actual, object expected, string message)
		{
			Assert.That(actual, Is.Not.EqualTo(expected), message);
		}

		public static void ShouldBeTheSameAs(this object actual, object expected)
		{
			Assert.That(actual, Is.SameAs(expected));
		}

		public static void ShouldBeTheSameAs(this object actual, object expected, string message)
		{
			Assert.That(actual, Is.SameAs(expected), message);
		}

		public static void ShouldNotBeTheSameAs(this object actual, object expected)
		{
			Assert.That(actual, Is.Not.SameAs(expected));
		}

		public static void ShouldNotBeTheSameAs(this object actual, object expected, string message)
		{
			Assert.That(actual, Is.Not.SameAs(expected), message);
		}

		public static void ShouldContain(this ICollection actual, object expected)
		{
			Assert.Contains(expected, actual);
		}

		public static void ShouldContain(this ICollection actual, object expected, string message)
		{
			Assert.Contains(expected, actual, message);
		}

		public static void ShouldContainItemOfType<T>(this IEnumerable enumerable)
		{
			foreach (var item in enumerable)
			{
				if (item.GetType().Equals(typeof(T)))
				{
					return;
				}
			}

			Assert.Fail("Collection did not contain a item of type {0}", typeof(T));
		}

		public static void ShouldContain(this string actual, string expected)
		{
			Assert.That(actual.Contains(expected));
		}

		public static void ShouldContain(this string actual, string expected, string message)
		{
			Assert.That(actual.Contains(expected), message);
		}

		public static void ShouldContain<T>(this IEnumerable<T> actual, T expected)
		{
			CollectionAssert.Contains(actual, expected);
		}

		public static void ShouldContain<T>(this IEnumerable<T> actual, T expected, string message)
		{
			CollectionAssert.Contains(actual, expected, message);
		}

		public static void ShouldNotContain<T>(this IEnumerable<T> actual, T expected)
		{
			CollectionAssert.DoesNotContain(actual, expected);
		}

		public static void ShouldNotContain<T>(this IEnumerable<T> actual, T expected, string  message)
		{
			CollectionAssert.DoesNotContain(actual, expected);
		}

		public static void ShouldBeGreaterThan(this IComparable arg1, IComparable arg2)
		{
			Assert.That(arg1, Is.GreaterThan(arg2));
		}

		public static void ShouldBeGreaterThan(this IComparable arg1, IComparable arg2, string message)
		{
			Assert.That(arg1, Is.GreaterThan(arg2),message);
		}

		public static void ShouldBeGreaterThanOrEqualTo(this IComparable arg1, IComparable arg2)
		{
			Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2));
		}

		public static void ShouldBeGreaterThanOrEqualTo(this IComparable arg1, IComparable arg2, string message)
		{
			Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2),message);
		}

		public static void ShouldBeLessThan(this IComparable arg1, IComparable arg2)
		{
			Assert.That(arg1, Is.LessThan(arg2));
		}

		public static void ShouldBeLessThan(this IComparable arg1, IComparable arg2, string message)
		{
			Assert.That(arg1, Is.LessThan(arg2), message);
		}

		public static void ShouldBeLessThanOrEqualTo(this IComparable arg1, IComparable arg2)
		{
			Assert.That(arg1, Is.LessThanOrEqualTo(arg2));
		}

		public static void ShouldBeLessThanOrEqualTo(this IComparable arg1, IComparable arg2, string message)
		{
			Assert.That(arg1, Is.LessThanOrEqualTo(arg2), message);
		}

		public static void ShouldBeAssignableFrom(this object actual, Type expected)
		{
			Assert.That(actual, Is.AssignableFrom(expected));
		}

		public static void ShouldBeAssignableFrom(this object actual, Type expected, string message)
		{
			Assert.That(actual, Is.AssignableFrom(expected), message);
		}

		public static void ShouldBeAssignableFrom<ExpectedType>(this Object actual)
		{
			actual.ShouldBeAssignableFrom(typeof (ExpectedType));
		}

		public static void ShouldBeAssignableFrom<ExpectedType>(this Object actual, string message)
		{
			actual.ShouldBeAssignableFrom(typeof(ExpectedType), message);
		}

		public static void ShouldNotBeAssignableFrom(this object actual, Type expected)
		{
			Assert.That(actual, Is.Not.AssignableFrom(expected));
		}

		public static void ShouldNotBeAssignableFrom(this object actual, Type expected, string message)
		{
			Assert.That(actual, Is.Not.AssignableFrom(expected), message);
		}

		public static void ShouldNotBeAssignableFrom<ExpectedType>(this object actual)
		{
			actual.ShouldNotBeAssignableFrom(typeof (ExpectedType));
		}

		public static void ShouldNotBeAssignableFrom<ExpectedType>(this object actual, string message)
		{
			actual.ShouldNotBeAssignableFrom(typeof(ExpectedType), message);
		}

		public static void ShouldBeEmpty(this string value)
		{
			Assert.That(value, Is.Empty);
		}

		public static void ShouldBeEmpty(this string value, string message)
		{
			Assert.That(value, Is.Empty, message);
		}

		public static void ShouldNotBeEmpty(this string value)
		{
			Assert.That(value, Is.Not.Empty);
		}

		public static void ShouldNotBeEmpty(this string value, string message)
		{
			Assert.That(value, Is.Not.Empty, message);
		}

		public static void ShouldBeEmpty(this ICollection collection)
		{
			Assert.That(collection, Is.Empty);
		}

		public static void ShouldBeEmpty(this ICollection collection, string message)
		{
			Assert.That(collection, Is.Empty, message);
		}

		public static void ShouldNotBeEmpty(this ICollection collection)
		{
			Assert.That(collection, Is.Not.Empty);
		}

		public static void ShouldNotBeEmpty(this ICollection collection, string message)
		{
			Assert.That(collection, Is.Not.Empty, message);
		}

		public static void ShouldBeInstanceOfType(this object actual, Type expected)
		{
			Assert.That(actual, Is.InstanceOf(expected));
		}

		public static void ShouldBeInstanceOfType(this object actual, Type expected, string message)
		{
			Assert.That(actual, Is.InstanceOf(expected), message);
		}

		public static void ShouldBeInstanceOf<TExpectedType>(this object actual)
		{
			actual.ShouldBeInstanceOfType(typeof (TExpectedType));
		}

		public static void ShouldBeInstanceOf<TExpectedType>(this object actual, string message)
		{
			actual.ShouldBeInstanceOfType(typeof(TExpectedType), message);
		}

		public static void ShouldNotBeInstanceOfType(this object actual, Type expected)
		{
			Assert.That(actual, Is.Not.InstanceOf(expected));
		}

		public static void ShouldNotBeInstanceOfType(this object actual, Type expected, string message)
		{
			Assert.That(actual, Is.Not.InstanceOf(expected), message);
		}

		public static void ShouldNotBeInstanceOf<TExpectedType>(this object actual)
		{
			actual.ShouldNotBeInstanceOfType(typeof (TExpectedType));
		}

		public static void ShouldNotBeInstanceOf<TExpectedType>(this object actual, string message)
		{
			actual.ShouldNotBeInstanceOfType(typeof(TExpectedType), message);
		}

		public static void ShouldBeNaN(this double value)
		{
			Assert.That(value, Is.NaN);
		}

		public static void ShouldBeNaN(this double value, string message)
		{
			Assert.That(value, Is.NaN, message);
		}

		public static void ShouldBeNull(this object value)
		{
			Assert.That(value, Is.Null);
		}

		public static void ShouldBeNull(this object value, string message)
		{
			Assert.That(value, Is.Null, message);
		}

		public static void ShouldNotBeNull(this object value)
		{
			Assert.That(value, Is.Not.Null);
		}

		public static void ShouldNotBeNull(this object value, string message)
		{
			Assert.That(value, Is.Not.Null, message);
		}

		public static void ShouldBeThrownBy(this Type exceptionType, Action action)
		{
			ShouldBeThrownBy(exceptionType, action, string.Empty);
		}

		public static void ShouldBeThrownBy(this Type exceptionType, Action action, string message)
		{
			Exception e = null;

			try
			{
				action();
			}
			catch (Exception ex)
			{
				e = ex;
			}

			e.ShouldNotBeNull(message);
			e.ShouldBeInstanceOfType(exceptionType, message);
		}
	}
}