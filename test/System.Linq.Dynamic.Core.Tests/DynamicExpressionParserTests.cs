﻿using NFluent;
using System.Collections.Generic;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;
using User = System.Linq.Dynamic.Core.Tests.Helpers.Models.User;

namespace System.Linq.Dynamic.Core.Tests
{
    public class DynamicExpressionParserTests
    {
        private class MyClass
        {
            public int Foo()
            {
                return 42;
            }
        }

        private class ComplexParseLambda1Result
        {
            public int? Age;
            public int TotalIncome;
            public string Name;
        }

        [DynamicLinqType]
        public class ComplexParseLambda3Result
        {
            public int? Age { get; set; }
            public int TotalIncome { get; set; }
        }

        public class CustomClassWithStaticMethod
        {
            public static int GetAge(int x) => x;
        }

        public class CustomTextClass
        {
            public CustomTextClass(string origin)
            {
                Origin = origin;
            }

            public string Origin { get; }

            public static implicit operator string(CustomTextClass customTextValue)
            {
                return customTextValue?.Origin;
            }

            public static implicit operator CustomTextClass(string origin)
            {
                return new CustomTextClass(origin);
            }

            public override string ToString()
            {
                return Origin;
            }
        }

        public class TextHolder
        {
            public TextHolder(string name, CustomTextClass note)
            {
                Name = name;
                Note = note;
            }

            public string Name { get; }

            public CustomTextClass Note { get; }

            public override string ToString()
            {
                return Name + " (" + Note + ")";
            }
        }

        public static class StaticHelper
        {
            public static Guid? GetGuid(string name)
            {
                return Guid.NewGuid();
            }
        }

        public class TestCustomTypeProvider : AbstractDynamicLinqCustomTypeProvider, IDynamicLinkCustomTypeProvider
        {
            private HashSet<Type> _customTypes;

            public virtual HashSet<Type> GetCustomTypes()
            {
                if (_customTypes != null)
                {
                    return _customTypes;
                }

                _customTypes =
                    new HashSet<Type>(
                        FindTypesMarkedWithDynamicLinqTypeAttribute(new[] { GetType().GetTypeInfo().Assembly }));
                _customTypes.Add(typeof(CustomClassWithStaticMethod));
                _customTypes.Add(typeof(StaticHelper));
                return _customTypes;
            }

            public Type ResolveType(string typeName)
            {
                return Type.GetType(typeName);
            }
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_UseParameterizedNamesInDynamicQuery_true()
        {
            // Assign
            var config = new ParsingConfig
            {
                UseParameterizedNamesInDynamicQuery = true
            };

            // Act
            var expression = DynamicExpressionParser.ParseLambda<string, bool>(config, true, "s => s == \"x\"");

            // Assert
            dynamic constantExpression = ((MemberExpression)(expression.Body as BinaryExpression).Right).Expression as ConstantExpression;
            dynamic wrappedObj = constantExpression.Value;

            var propertyInfo = wrappedObj.GetType().GetProperty("Value", BindingFlags.Instance | BindingFlags.Public);
            string value = propertyInfo.GetValue(wrappedObj) as string;

            Check.That(value).IsEqualTo("x");
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_UseParameterizedNamesInDynamicQuery_false()
        {
            // Assign
            var config = new ParsingConfig
            {
                UseParameterizedNamesInDynamicQuery = false
            };

            // Act
            var expression = DynamicExpressionParser.ParseLambda<string, bool>(config, true, "s => s == \"x\"");

            // Assert
            dynamic constantExpression = (ConstantExpression)(expression.Body as BinaryExpression).Right;
            string value = constantExpression.Value;

            Check.That(value).IsEqualTo("x");
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_ToList()
        {
            // Arrange
            var testList = User.GenerateSampleModels(51);
            var qry = testList.AsQueryable();

            // Act
            string query = "OrderBy(gg => gg.Income).ToList()";
            LambdaExpression expression = DynamicExpressionParser.ParseLambda(qry.GetType(), null, query);
            Delegate del = expression.Compile();
            IEnumerable<dynamic> result = del.DynamicInvoke(qry) as IEnumerable<dynamic>;

            var expected = qry.OrderBy(gg => gg.Income).ToList();

            // Assert
            Check.That(result).IsNotNull();
            Check.That(result).HasSize(expected.Count);
            Check.That(result.ToArray()[0]).Equals(expected[0]);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_Complex_1()
        {
            // Arrange
            var testList = User.GenerateSampleModels(51);
            var qry = testList.AsQueryable();

            var externals = new Dictionary<string, object>
            {
                {"Users", qry}
            };

            // Act
            string query =
                "Users.GroupBy(x => new { x.Profile.Age }).OrderBy(gg => gg.Key.Age).Select(j => new (j.Key.Age, j.Sum(k => k.Income) As TotalIncome))";
            LambdaExpression expression = DynamicExpressionParser.ParseLambda(null, query, externals);
            Delegate del = expression.Compile();
            IEnumerable<dynamic> result = del.DynamicInvoke() as IEnumerable<dynamic>;

            var expected = qry.GroupBy(x => new { x.Profile.Age }).OrderBy(gg => gg.Key.Age)
                .Select(j => new { j.Key.Age, TotalIncome = j.Sum(k => k.Income) })
                .Select(c => new ComplexParseLambda1Result { Age = c.Age, TotalIncome = c.TotalIncome }).Cast<dynamic>()
                .ToArray();

            // Assert
            Check.That(result).IsNotNull();
            Check.That(result).HasSize(expected.Length);
            Check.That(result.ToArray()[0]).Equals(expected[0]);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_Complex_2()
        {
            // Arrange
            var testList = User.GenerateSampleModels(51);
            var qry = testList.AsQueryable();

            // Act
            string query =
                "GroupBy(x => new { x.Profile.Age }, it).OrderBy(gg => gg.Key.Age).Select(j => new (j.Key.Age, j.Sum(k => k.Income) As TotalIncome))";
            LambdaExpression expression = DynamicExpressionParser.ParseLambda(qry.GetType(), null, query);
            Delegate del = expression.Compile();
            IEnumerable<dynamic> result = del.DynamicInvoke(qry) as IEnumerable<dynamic>;

            var expected = qry.GroupBy(x => new { x.Profile.Age }, x => x).OrderBy(gg => gg.Key.Age)
                .Select(j => new { j.Key.Age, TotalIncome = j.Sum(k => k.Income) })
                .Select(c => new ComplexParseLambda1Result { Age = c.Age, TotalIncome = c.TotalIncome }).Cast<dynamic>()
                .ToArray();

            // Assert
            Check.That(result).IsNotNull();
            Check.That(result).HasSize(expected.Length);
            Check.That(result.ToArray()[0]).Equals(expected[0]);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_Complex_3()
        {
            var config = new ParsingConfig
            {
                CustomTypeProvider = new TestCustomTypeProvider()
            };

            // Arrange
            var testList = User.GenerateSampleModels(51);
            var qry = testList.AsQueryable();

            var externals = new Dictionary<string, object>
            {
                {"Users", qry}
            };

            // Act
            string stringExpression =
                "Users.GroupBy(x => new { x.Profile.Age }).OrderBy(gg => gg.Key.Age).Select(j => new System.Linq.Dynamic.Core.Tests.DynamicExpressionParserTests+ComplexParseLambda3Result{j.Key.Age, j.Sum(k => k.Income) As TotalIncome})";
            LambdaExpression expression =
                DynamicExpressionParser.ParseLambda(config, null, stringExpression, externals);
            Delegate del = expression.Compile();
            IEnumerable<dynamic> result = del.DynamicInvoke() as IEnumerable<dynamic>;

            var expected = qry.GroupBy(x => new { x.Profile.Age }).OrderBy(gg => gg.Key.Age)
                .Select(j => new ComplexParseLambda3Result { Age = j.Key.Age, TotalIncome = j.Sum(k => k.Income) })
                .Cast<dynamic>().ToArray();

            // Assert
            Check.That(result).IsNotNull();
            Check.That(result).HasSize(expected.Length);
            Check.That(result.ToArray()[0]).Equals(expected[0]);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_Select_1()
        {
            // Arrange
            var testList = User.GenerateSampleModels(51);
            var qry = testList.AsQueryable();

            var externals = new Dictionary<string, object>
            {
                {"Users", qry}
            };

            // Act
            string query = "Users.Select(j => new User(j.Income As Income))";
            LambdaExpression expression = DynamicExpressionParser.ParseLambda(null, query, externals);
            Delegate del = expression.Compile();
            object result = del.DynamicInvoke();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_Select_2()
        {
            // Arrange
            var testList = User.GenerateSampleModels(5);
            var qry = testList.AsQueryable();

            var externals = new Dictionary<string, object>
            {
                {"Users", qry}
            };

            // Act
            string query = "Users.Select(j => j)";
            LambdaExpression expression = DynamicExpressionParser.ParseLambda(null, query, externals);
            Delegate del = expression.Compile();
            object result = del.DynamicInvoke();

            // Assert
            Assert.NotNull(result);
        }

        // https://github.com/StefH/System.Linq.Dynamic.Core/issues/58
        [Fact]
        public void DynamicExpressionParser_ParseLambda_4_Issue58()
        {
            var expressionParams = new[]
            {
                Expression.Parameter(typeof(MyClass), "myObj")
            };

            var myClassInstance = new MyClass();
            var invokersMerge = new List<object> { myClassInstance };

            LambdaExpression expression =
                DynamicExpressionParser.ParseLambda(false, expressionParams, null, "myObj.Foo()");
            Delegate del = expression.Compile();
            object result = del.DynamicInvoke(invokersMerge.ToArray());

            Check.That(result).Equals(42);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_DuplicateParameterNames_ThrowsException()
        {
            // Arrange
            var parameters = new[]
            {
                Expression.Parameter(typeof(int), "x"),
                Expression.Parameter(typeof(int), "x")
            };

            // Act and Assert
            Check.ThatCode(() => DynamicExpressionParser.ParseLambda(parameters, typeof(bool), "it == 42"))
                .Throws<ParseException>()
                .WithMessage("The identifier 'x' was defined more than once");
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_EmptyParameterList()
        {
            // Arrange
            var pEmpty = new ParameterExpression[] { };

            // Act
            var @delegate = DynamicExpressionParser.ParseLambda(pEmpty, null, "1+2").Compile();
            int? result = @delegate.DynamicInvoke() as int?;

            // Assert
            Check.That(result).Equals(3);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_ParameterName()
        {
            // Arrange
            var parameters = new[]
            {
                Expression.Parameter(typeof(int), "x")
            };

            // Assert
            var expressionX = DynamicExpressionParser.ParseLambda(parameters, typeof(bool), "x == 42");
            var expressionIT = DynamicExpressionParser.ParseLambda(parameters, typeof(bool), "it == 42");

            // Assert
            Assert.Equal(typeof(bool), expressionX.Body.Type);
            Assert.Equal(typeof(bool), expressionIT.Body.Type);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_ParameterName_Empty()
        {
            // Arrange
            var parameters = new[]
            {
                Expression.Parameter(typeof(int), "")
            };

            // Assert
            var expression = DynamicExpressionParser.ParseLambda(parameters, typeof(bool), "it == 42");

            // Assert
            Assert.Equal(typeof(bool), expression.Body.Type);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_ParameterName_Null()
        {
            // Arrange
            var parameters = new[]
            {
                Expression.Parameter(typeof(int), null)
            };

            // Assert
            var expression = DynamicExpressionParser.ParseLambda(parameters, typeof(bool), "it == 42");

            // Assert
            Assert.Equal(typeof(bool), expression.Body.Type);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_ParameterExpressionMethodCall_ReturnsIntExpression()
        {
            var expression = DynamicExpressionParser.ParseLambda(true,
                new[] { Expression.Parameter(typeof(int), "x") },
                typeof(int),
                "x + 1");
            Assert.Equal(typeof(int), expression.Body.Type);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_RealNumbers()
        {
            var parameters = new ParameterExpression[0];

            var result1 = DynamicExpressionParser.ParseLambda(parameters, typeof(double), "0.10");
            var result2 = DynamicExpressionParser.ParseLambda(parameters, typeof(double), "0.10d");
            var result3 = DynamicExpressionParser.ParseLambda(parameters, typeof(float), "0.10f");
            var result4 = DynamicExpressionParser.ParseLambda(parameters, typeof(decimal), "0.10m");

            // Assert
            Assert.Equal(0.10d, result1.Compile().DynamicInvoke());
            Assert.Equal(0.10d, result2.Compile().DynamicInvoke());
            Assert.Equal(0.10f, result3.Compile().DynamicInvoke());
            Assert.Equal(0.10m, result4.Compile().DynamicInvoke());
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_StringLiteral_ReturnsBooleanLambdaExpression()
        {
            var expression = DynamicExpressionParser.ParseLambda(
                new[] { Expression.Parameter(typeof(string), "Property1") }, typeof(bool), "Property1 == \"test\"");
            Assert.Equal(typeof(bool), expression.Body.Type);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_StringLiteralEmpty_ReturnsBooleanLambdaExpression()
        {
            var expression = DynamicExpressionParser.ParseLambda(
                new[] { Expression.Parameter(typeof(string), "Property1") }, typeof(bool), "Property1 == \"\"");
            Assert.Equal(typeof(bool), expression.Body.Type);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_Config_StringLiteralEmpty_ReturnsBooleanLambdaExpression()
        {
            var config = new ParsingConfig();
            var expression = DynamicExpressionParser.ParseLambda(
                new[] { Expression.Parameter(typeof(string), "Property1") }, typeof(bool), "Property1 == \"\"");
            Assert.Equal(typeof(bool), expression.Body.Type);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_StringLiteralEmbeddedQuote_ReturnsBooleanLambdaExpression()
        {
            string expectedRightValue = "\"test \\\"string\"";

            // Act
            var expression = DynamicExpressionParser.ParseLambda(
                new[] { Expression.Parameter(typeof(string), "Property1") },
                typeof(bool),
                string.Format("Property1 == {0}", expectedRightValue));

            string rightValue = ((BinaryExpression)expression.Body).Right.ToString();
            Assert.Equal(typeof(bool), expression.Body.Type);
            Assert.Equal(expectedRightValue, rightValue);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_StringLiteralStartEmbeddedQuote_ReturnsBooleanLambdaExpression()
        {
            // Assign
            string expectedRightValue = "\"\\\"test\"";

            var expression = DynamicExpressionParser.ParseLambda(
                new[] { Expression.Parameter(typeof(string), "Property1") },
                typeof(bool),
                string.Format("Property1 == {0}", expectedRightValue));

            string rightValue = ((BinaryExpression)expression.Body).Right.ToString();
            Assert.Equal(typeof(bool), expression.Body.Type);
            Assert.Equal(expectedRightValue, rightValue);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_StringLiteral_MissingClosingQuote()
        {
            string expectedRightValue = "\"test\\\"";

            Assert.Throws<ParseException>(() => DynamicExpressionParser.ParseLambda(
                new[] { Expression.Parameter(typeof(string), "Property1") },
                typeof(bool),
                string.Format("Property1 == {0}", expectedRightValue)));
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_StringLiteralEscapedBackslash_ReturnsBooleanLambdaExpression()
        {
            // Assign
            string expectedRightValue = "\"test\\string\"";

            // Act
            var expression = DynamicExpressionParser.ParseLambda(
                new[] { Expression.Parameter(typeof(string), "Property1") },
                typeof(bool),
                string.Format("Property1 == {0}", expectedRightValue));

            string rightValue = ((BinaryExpression)expression.Body).Right.ToString();
            Assert.Equal(typeof(Boolean), expression.Body.Type);
            Assert.Equal(expectedRightValue, rightValue);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_TupleToStringMethodCall_ReturnsStringLambdaExpression()
        {
            var expression = DynamicExpressionParser.ParseLambda(
                typeof(Tuple<int>),
                typeof(string),
                "it.ToString()");
            Assert.Equal(typeof(string), expression.ReturnType);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_IllegalMethodCall_ThrowsException()
        {
            Check.ThatCode(() => { DynamicExpressionParser.ParseLambda(typeof(IO.FileStream), null, "it.Close()"); })
                .Throws<ParseException>().WithMessage("Methods on type 'Stream' are not accessible");
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_CustomMethod()
        {
            // Assign
            var config = new ParsingConfig
            {
                CustomTypeProvider = new TestCustomTypeProvider()
            };

            var context = new CustomClassWithStaticMethod();
            string expression =
                $"{nameof(CustomClassWithStaticMethod)}.{nameof(CustomClassWithStaticMethod.GetAge)}(10)";

            // Act
            var lambdaExpression =
                DynamicExpressionParser.ParseLambda(config, typeof(CustomClassWithStaticMethod), null, expression);
            Delegate del = lambdaExpression.Compile();
            int result = (int)del.DynamicInvoke(context);

            // Assert
            Check.That(result).IsEqualTo(10);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_With_InnerStringLiteral()
        {
            var originalTrueValue = "simple + \"quoted\"";
            var doubleQuotedTrueValue = "simple + \"\"quoted\"\"";
            var expressionText = $"iif(1>0, \"{doubleQuotedTrueValue}\", \"false\")";
            var lambda = DynamicExpressionParser.ParseLambda(typeof(string), null, expressionText);
            var del = lambda.Compile();
            object result = del.DynamicInvoke(string.Empty);
            Check.That(result).IsEqualTo(originalTrueValue);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_With_Guid_Equals_Null()
        {
            // Arrange
            var user = new User();
            Guid guidEmpty = Guid.Empty;
            Guid someId = Guid.NewGuid();
            string expressionText = $"iif(@0.Id == null, @0.Id == Guid.Parse(\"{someId}\"), Id == Id)";

            // Act
            var lambda = DynamicExpressionParser.ParseLambda(typeof(User), null, expressionText, user);
            var boolLambda = lambda as Expression<Func<User, bool>>;
            Assert.NotNull(boolLambda);

            var del = lambda.Compile();
            bool result = (bool)del.DynamicInvoke(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_With_Null_Equals_Guid()
        {
            // Arrange
            var user = new User();
            Guid guidEmpty = Guid.Empty;
            Guid someId = Guid.NewGuid();
            string expressionText = $"iif(null == @0.Id, @0.Id == Guid.Parse(\"{someId}\"), Id == Id)";

            // Act
            var lambda = DynamicExpressionParser.ParseLambda(typeof(User), null, expressionText, user);
            var boolLambda = lambda as Expression<Func<User, bool>>;
            Assert.NotNull(boolLambda);

            var del = lambda.Compile();
            bool result = (bool)del.DynamicInvoke(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_With_Guid_Equals_String()
        {
            // Arrange
            Guid someId = Guid.NewGuid();
            Guid anotherId = Guid.NewGuid();
            var user = new User();
            user.Id = someId;
            Guid guidEmpty = Guid.Empty;
            string expressionText =
                $"iif(@0.Id == \"{someId}\", Guid.Parse(\"{guidEmpty}\"), Guid.Parse(\"{anotherId}\"))";

            // Act
            var lambda = DynamicExpressionParser.ParseLambda(typeof(User), null, expressionText, user);
            var guidLambda = lambda as Expression<Func<User, Guid>>;
            Assert.NotNull(guidLambda);

            var del = lambda.Compile();
            Guid result = (Guid)del.DynamicInvoke(user);

            // Assert
            Assert.Equal(guidEmpty, result);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_With_Concat_String_CustomType()
        {
            // Arrange
            string name = "name1";
            string note = "note1";
            var textHolder = new TextHolder(name, note);
            string expressionText = "Name + \" (\" + Note + \")\"";

            // Act 1
            var lambda = DynamicExpressionParser.ParseLambda(typeof(TextHolder), null, expressionText, textHolder);
            var stringLambda = lambda as Expression<Func<TextHolder, string>>;

            // Assert 1
            Assert.NotNull(stringLambda);

            // Act 2
            var del = lambda.Compile();
            string result = (string)del.DynamicInvoke(textHolder);

            // Assert 2
            Assert.Equal("name1 (note1)", result);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_With_Concat_CustomType_String()
        {
            // Arrange
            string name = "name1";
            string note = "note1";
            var textHolder = new TextHolder(name, note);
            string expressionText = "Note + \" (\" + Name + \")\"";

            // Act 1
            var lambda = DynamicExpressionParser.ParseLambda(typeof(TextHolder), null, expressionText, textHolder);
            var stringLambda = lambda as Expression<Func<TextHolder, string>>;

            // Assert 1
            Assert.NotNull(stringLambda);

            // Act 2
            var del = lambda.Compile();
            string result = (string)del.DynamicInvoke(textHolder);

            // Assert 2
            Assert.Equal("note1 (name1)", result);
        }

        [Fact]
        public void DynamicExpressionParser_ParseLambda_Operator_Less_Greater_With_Guids()
        {
            var config = new ParsingConfig
            {
                CustomTypeProvider = new TestCustomTypeProvider()
            };

            // Arrange
            Guid someId = Guid.NewGuid();
            Guid anotherId = Guid.NewGuid();
            var user = new User();
            user.Id = someId;
            Guid guidEmpty = Guid.Empty;
            string expressionText =
                $"iif(@0.Id == StaticHelper.GetGuid(\"name\"), Guid.Parse(\"{guidEmpty}\"), Guid.Parse(\"{anotherId}\"))";

            // Act
            var lambda = DynamicExpressionParser.ParseLambda(config, typeof(User), null, expressionText, user);
            var guidLambda = lambda as Expression<Func<User, Guid>>;
            Assert.NotNull(guidLambda);

            var del = lambda.Compile();
            Guid result = (Guid)del.DynamicInvoke(user);

            // Assert
            Assert.Equal(anotherId, result);
        }

        [Theory]
        [InlineData("c => c.Age == 8", "c => (c.Age == 8)")]
        [InlineData("c => c.Name == \"test\"", "c => (c.Name == \"test\")")]
        public void DynamicExpressionParser_ParseLambda_RenameParameterExpression(string expressionAsString, string expected)
        {
            // Arrange
            var config = new ParsingConfig
            {
                RenameParameterExpression = true
            };

            // Act
            var expression = DynamicExpressionParser.ParseLambda<ComplexParseLambda1Result, bool>(config, true, expressionAsString);
            string result = expression.ToString();

            // Assert
            Check.That(result).IsEqualTo(expected);
        }
    }
}
