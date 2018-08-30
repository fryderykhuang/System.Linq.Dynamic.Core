# 1.0.8.17 (27 August 2018)

 - [#200](https://github.com/StefH/System.Linq.Dynamic.Core/pull/200) - Fix for parsing Guid and string in the same condition contributed by Oleg ([OlegNadymov](https://github.com/OlegNadymov))

Commits: b78629f5b5...b78629f5b5


# 1.0.8.16 (19 August 2018)

 - [#191](https://github.com/StefH/System.Linq.Dynamic.Core/issues/191) - Feature: re-enable support for uap10
 - [#198](https://github.com/StefH/System.Linq.Dynamic.Core/pull/198) - re-enable UAP10 support contributed by Stef Heyenrath ([StefH](https://github.com/StefH))

Commits: eac1fdc0ea...eac1fdc0ea


# 1.0.8.15 (17 August 2018)

 - [#197](https://github.com/StefH/System.Linq.Dynamic.Core/pull/197) - Added EvaluateGroupByAtDatabase For EF Core 2.1 contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#196](https://github.com/StefH/System.Linq.Dynamic.Core/issues/196) - Question: Not applicable aggregate method 'Any' exists
 - [#165](https://github.com/StefH/System.Linq.Dynamic.Core/issues/165) - Consider fit the rule of AnonymousTypes for EFCore2.1? +feature

Commits: c730a78703...1e0ed4e692


# 1.0.8.14 (14 August 2018)

 - [#195](https://github.com/StefH/System.Linq.Dynamic.Core/pull/195) - Fix the problem with inner double quotes contributed by Oleg ([OlegNadymov](https://github.com/OlegNadymov))
 - [#194](https://github.com/StefH/System.Linq.Dynamic.Core/pull/194) - Test for sonarcloud contributed by Stef Heyenrath ([StefH](https://github.com/StefH))

Commits: f1cfbe2063...870eb29888


# 1.0.8.13 (02 August 2018)

 - [#193](https://github.com/StefH/System.Linq.Dynamic.Core/pull/193) - Fix for ParseLambda with itType and resultType: correct order of arguments contributed by Oleg ([OlegNadymov](https://github.com/OlegNadymov))
 - [#190](https://github.com/StefH/System.Linq.Dynamic.Core/pull/190) - Add SonarCloud (#186) contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#187](https://github.com/StefH/System.Linq.Dynamic.Core/issues/187) - Add custom static classes for parsing
 - [#186](https://github.com/StefH/System.Linq.Dynamic.Core/issues/186) - Feature: include SonarCloud code checks +feature

Commits: f1cfbe2063...fa1b6f29fc


# 1.0.8.12 (27 July 2018)

 - [#189](https://github.com/StefH/System.Linq.Dynamic.Core/pull/189) - Fix conversion from a non-nullable value type to the nullable value type contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#188](https://github.com/StefH/System.Linq.Dynamic.Core/issues/188) - Issue: Implicitly conversion from a non-nullable value type to the nullable form of that value type is broken?
 - [#180](https://github.com/StefH/System.Linq.Dynamic.Core/issues/180) - Question: GroupBy fails for field named SHORT
 - [#178](https://github.com/StefH/System.Linq.Dynamic.Core/issues/178) - Question: No generic method 'Contains' on type 'System.Linq.Enumerable
 - [#177](https://github.com/StefH/System.Linq.Dynamic.Core/pull/177) - Feature: Remove built-in references from netstandard2.0 target contributed by Alexander Zaytsev ([hazzik](https://github.com/hazzik))
 - [#53](https://github.com/StefH/System.Linq.Dynamic.Core/issues/53) - Question: External Methods call

Commits: 2b4c6a5d76...59fb884ce4


# 1.0.8.11 (06 June 2018)

 - [#172](https://github.com/StefH/System.Linq.Dynamic.Core/issues/172) - Issue: DynamicQueryableExtensions.OrderBy extension method not using ParsingConfig parameter

Commits: ...


# 1.0.8.10 (05 June 2018)

 - [#170](https://github.com/StefH/System.Linq.Dynamic.Core/issues/170) - Question: Support to build Expressions besides LambdaExpressions
 - [#155](https://github.com/StefH/System.Linq.Dynamic.Core/issues/155) - Question: OrderByDescending availability
 - [#143](https://github.com/StefH/System.Linq.Dynamic.Core/issues/143) - Question : How to orderby an attribute of a List

Commits: ...


# 1.0.8.9 (26 May 2018)

 - [#166](https://github.com/StefH/System.Linq.Dynamic.Core/pull/166) - Feature: Added support for implicit type conversions contributed by ([arjenvrh](https://github.com/arjenvrh))

Commits: 12704c2d9a...12704c2d9a


# 1.0.8.8 (21 May 2018)

 - [#168](https://github.com/StefH/System.Linq.Dynamic.Core/pull/168) - Fixed ConstantExpressionHelper.cs (#167) contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#167](https://github.com/StefH/System.Linq.Dynamic.Core/issues/167) - Issue: Memory leak in `ConstantExpressionHelper.cs` +fix

Commits: 52bb6f3a83...52bb6f3a83


# 1.0.8.7 (08 May 2018)

 - [#156](https://github.com/StefH/System.Linq.Dynamic.Core/pull/156) - Fix parsing config contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))

Commits: c17a5ebaf6...c17a5ebaf6


# 1.0.8.6 (28 April 2018)

 - [#161](https://github.com/StefH/System.Linq.Dynamic.Core/issues/161) - Error (1.0.8.3 to 1.0.8.4 on EF 6.2) "No generic method 'OrderBy' on type System.Linq.Queryable"
 - [#160](https://github.com/StefH/System.Linq.Dynamic.Core/issues/160) - Question: Generic ParseLambda method
 - [#158](https://github.com/StefH/System.Linq.Dynamic.Core/pull/158) - Fix157 contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#157](https://github.com/StefH/System.Linq.Dynamic.Core/issues/157) - Issue : SkipWhile Method not found in mono +fix

Commits: 57e7c4378d...85c7cde282


# 1.0.8.5 (27 April 2018)

 - [#159](https://github.com/StefH/System.Linq.Dynamic.Core/pull/159) - Performance fix (#153) contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#153](https://github.com/StefH/System.Linq.Dynamic.Core/issues/153) - Issue: Performance while working with EF core
 - [#151](https://github.com/StefH/System.Linq.Dynamic.Core/issues/151) - Parse Query Syntax like Code

Commits: f48b512e3a...f48b512e3a


# 1.0.8.3 (30 March 2018)

 - [#150](https://github.com/StefH/System.Linq.Dynamic.Core/pull/150) - Feature: Support Binary & For String and Int contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988)) +feature
 - [#137](https://github.com/StefH/System.Linq.Dynamic.Core/pull/137) - Feature: Add support for querying a IQueryable<dynamic> contributed by Nick Darvey ([NickDarvey](https://github.com/NickDarvey))

Commits: 864f75f75d...7302169760


# 1.0.8.2 (09 January 2018)

 - [#130](https://github.com/StefH/System.Linq.Dynamic.Core/issues/130) - BUG: Dynamic new in Where() causes NRE

Commits: ca622f4e71...ca622f4e71


# 1.0.8.1 (05 January 2018)

 - [#135](https://github.com/StefH/System.Linq.Dynamic.Core/pull/135) - Add DbGeography to predefined types to allow advanced spatial queries. contributed by ([czielin](https://github.com/czielin))
 - [#134](https://github.com/StefH/System.Linq.Dynamic.Core/issues/134) - Accessing DbGeography methods/properties
 - [#129](https://github.com/StefH/System.Linq.Dynamic.Core/issues/129) - ToDynamicList/ToDynamicArray cannot actually cast to specified type in .net core 2 +fix

Commits: e584361eaa...e584361eaa


# 1.0.8.0 (16 December 2017)

 - [#127](https://github.com/StefH/System.Linq.Dynamic.Core/pull/127) - Refactored Parser contributed by Stef Heyenrath ([StefH](https://github.com/StefH))

Commits: bd69f2d328...02fd83b24b


# 1.0.7.13 (29 November 2017)

 - [#125](https://github.com/StefH/System.Linq.Dynamic.Core/issues/125) - Not compatable with dotnet Core 2. +fix
 - [#124](https://github.com/StefH/System.Linq.Dynamic.Core/issues/124) - OrderBy produces error.
 - [#123](https://github.com/StefH/System.Linq.Dynamic.Core/pull/123) - appveyor contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#122](https://github.com/StefH/System.Linq.Dynamic.Core/issues/122) - Join with int list
  - [#120](https://github.com/StefH/System.Linq.Dynamic.Core/issues/120) - Error with parsing
 - [#117](https://github.com/StefH/System.Linq.Dynamic.Core/pull/117) - New features contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#114](https://github.com/StefH/System.Linq.Dynamic.Core/issues/114) - Dynamic Linq Query not usable with ORM Provider +fix

Commits: a8113531cd...739c2ebdbf


# 1.0.7.12 (09 November 2017)

 - [#116](https://github.com/StefH/System.Linq.Dynamic.Core/pull/116) - Bugfix DynamicLinq when using IQueryable contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#115](https://github.com/StefH/System.Linq.Dynamic.Core/pull/115) - Dynamic Linq Query not usable with ORM Provider (fix for #114) contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#113](https://github.com/StefH/System.Linq.Dynamic.Core/issues/113) - .pdb is missing in nuget +fix

Commits: 60d4c3845e...28d726ed2a


# 1.0.7.11 (01 November 2017)

 - [#112](https://github.com/StefH/System.Linq.Dynamic.Core/issues/112) - Support NETStandard 2.0 +enhancement
 - [#111](https://github.com/StefH/System.Linq.Dynamic.Core/issues/111) - Issue: Incorrect Nullable<> parsing +fix
 - [#109](https://github.com/StefH/System.Linq.Dynamic.Core/issues/109) - Not able to build with VS2017
 - [#107](https://github.com/StefH/System.Linq.Dynamic.Core/issues/107) - Type conversions generated in cases where they're not needed. +fix

Commits: 8028fecce4...87cd4d11fa


# 1.0.7.9 (12 September 2017)

 - [#104](https://github.com/StefH/System.Linq.Dynamic.Core/issues/104) - Add PDB to nuget package +enhancement
 - [#103](https://github.com/StefH/System.Linq.Dynamic.Core/pull/103) - support group by with 2 parameters, add tolist contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#102](https://github.com/StefH/System.Linq.Dynamic.Core/issues/102) - Aggregate method does not work with Average function

Commits: a02f3d64fa...2b49cde9f4


# 1.0.7.7 (29 August 2017)

 - [#102](https://github.com/StefH/System.Linq.Dynamic.Core/issues/102) - Aggregate method does not work with Average function
 - [#100](https://github.com/StefH/System.Linq.Dynamic.Core/pull/100) - Feature: NullPropagation operator contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#99](https://github.com/StefH/System.Linq.Dynamic.Core/pull/99) - Added DynamicEnumerable Async extension methods contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#97](https://github.com/StefH/System.Linq.Dynamic.Core/issues/97) - Dynamic Select with string Concatenation

Commits: a02f3d64fa...0f30f422b4


# 1.0.7.6 (08 juli 2017)

 - [#94](https://github.com/StefH/System.Linq.Dynamic.Core/issues/94) - Issue: ParseException: Operator '==' incompatible with operand types 'ObjectId' and 'ObjectId' +fix

Commits: a02f3d64fa...5e4d7f6e30


# 1.0.7.6 (08 juli 2017) (08 juli 2017)

 - [#93](https://github.com/StefH/System.Linq.Dynamic.Core/pull/93) - Issue: Fix uap10 build in appveyor contributed by Stef Heyenrath ([StefH](https://github.com/StefH))
 - [#33](https://github.com/StefH/System.Linq.Dynamic.Core/issues/33) - Package 1.0.6.3 install fails for UWP App +fix

Commits: a02f3d64fa...5e4d7f6e30


# 1.0.7.5 (28 juni 2017) (28 juni 2017)

 - [#72](https://github.com/StefH/System.Linq.Dynamic.Core/issues/72) - Issue: Re-enable support for uap10.0 +fix
 - [#33](https://github.com/StefH/System.Linq.Dynamic.Core/issues/33) - Package 1.0.6.3 install fails for UWP App +fix

Commits: a02f3d64fa...a41b67a2ef


# 1.0.7.4 (27 juni 2017) (27 juni 2017)

 - [#92](https://github.com/StefH/System.Linq.Dynamic.Core/pull/92) - Feature: Adds support for decimal qualifiers. Resolves #91 contributed by Pablo Ferraris ([pferraris](https://github.com/pferraris))
 - [#91](https://github.com/StefH/System.Linq.Dynamic.Core/issues/91) - Issue: Support for decimal qualifiers 'M' & 'm' +fix
 - [#90](https://github.com/StefH/System.Linq.Dynamic.Core/issues/90) - Issue: ParseIntegerLiteral Int16 +fix
 - [#84](https://github.com/StefH/System.Linq.Dynamic.Core/issues/84) - Issue: DynamicClassFactory not caching generated types +fix
 - [#83](https://github.com/StefH/System.Linq.Dynamic.Core/issues/83) - Issue: Problem with DynamicExpressionParser.ParseLambda & external ParameterExpression

Commits: a02f3d64fa...ab249d498a


# 1.0.7.3 (01 juni 2017) (01 juni 2017)

 - [#86](https://github.com/StefH/System.Linq.Dynamic.Core/pull/86) - [Fix] Fixed null in Parameter and added functionality Binary And and Or with different Types contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))

Commits: a02f3d64fa...a1096799c2


# 1.0.7.2 (01 juni 2017) (01 juni 2017)

 - [#86](https://github.com/StefH/System.Linq.Dynamic.Core/pull/86) - [Fix] Fixed null in Parameter and added functionality Binary And and Or with different Types contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))

Commits: a02f3d64fa...35bdf2c0c7


# 1.0.7.1 (31 mei 2017) (31 mei 2017)

 - [#85](https://github.com/StefH/System.Linq.Dynamic.Core/pull/85) - [Fix] Guid? == null comparison contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#82](https://github.com/StefH/System.Linq.Dynamic.Core/issues/82) - Feature: Add DefaultIfEmpty +enhancement
 - [#80](https://github.com/StefH/System.Linq.Dynamic.Core/pull/80) - Feature: Usage of cached Lambda Expressions contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))

Commits: a02f3d64fa...4252212620


# 1.0.7.0 (17 mei 2017) (17 mei 2017)

 - [#80](https://github.com/StefH/System.Linq.Dynamic.Core/pull/80) - Feature: Usage of cached Lambda Expressions contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#79](https://github.com/StefH/System.Linq.Dynamic.Core/issues/79) - DynamicExpressionParser does not allow empty parameter lists. +fix
 - [#78](https://github.com/StefH/System.Linq.Dynamic.Core/pull/78) - New feature: GroupJoin contributed by ([Maschmi](https://github.com/Maschmi)) +enhancement
 - [#77](https://github.com/StefH/System.Linq.Dynamic.Core/pull/77) - New features: Hexadecimal integers and array initializers contributed by David Cizek ([DavidCizek](https://github.com/DavidCizek))
 - [#76](https://github.com/StefH/System.Linq.Dynamic.Core/pull/76) - Fix - shift operators work only for int, short, ushort, byte, sbyte. contributed by David Cizek ([DavidCizek](https://github.com/DavidCizek))
 - [#75](https://github.com/StefH/System.Linq.Dynamic.Core/issues/75) - GroupBy clause add an "Item" property when projects the query
 - [#74](https://github.com/StefH/System.Linq.Dynamic.Core/issues/74) - Join on nullable and not nullable type throws exception +fix
 - [#73](https://github.com/StefH/System.Linq.Dynamic.Core/issues/73) - Feature: Extend OrderBy functionality +enhancement
 - [#70](https://github.com/StefH/System.Linq.Dynamic.Core/issues/70) - Move all tests into 1 test project +enhancement
 - [#67](https://github.com/StefH/System.Linq.Dynamic.Core/issues/67) - Convert Project to VS2017 +enhancement
 - [#66](https://github.com/StefH/System.Linq.Dynamic.Core/issues/66) - Is there Way to enter a Complex query
 - [#63](https://github.com/StefH/System.Linq.Dynamic.Core/issues/63) - Syntax IN dont work with Enums
 - [#58](https://github.com/StefH/System.Linq.Dynamic.Core/issues/58) - Parse Lambda
 - [#49](https://github.com/StefH/System.Linq.Dynamic.Core/issues/49) - .Contains("") operation Exception
 - [#44](https://github.com/StefH/System.Linq.Dynamic.Core/issues/44) - Casting a int to a nullable int will throw an error when using linq to entities"Only parameterless constructors and initializers are supported in LINQ to Entities"

Commits: a02f3d64fa...c21b1be15c


# 1.0.6.13 (08 April 2017)

 - [#68](https://github.com/StefH/System.Linq.Dynamic.Core/pull/68) - Work on #66 -> Should work now. Tests will follow on VS2017 support! contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))

Commits: a02f3d64fa...9fa29d7b3b


# vNext

 - [#69](https://github.com/StefH/System.Linq.Dynamic.Core/pull/69) - Fix - when method has object parameter and ValueType value is passed into this method, result is exception in System.Dynamic.Utils.ExpressionUtils.ValidateOneArgument. contributed by David Cizek ([DavidCizek](https://github.com/DavidCizek))
 - [#65](https://github.com/StefH/System.Linq.Dynamic.Core/issues/65) - Support embedded quotes in string literal +enhancement
 - [#62](https://github.com/StefH/System.Linq.Dynamic.Core/issues/62) - OrderBy Chaining +fix
 - [#61](https://github.com/StefH/System.Linq.Dynamic.Core/issues/61) - String[].Contains(String) expression translated to first array element contains
 - [#60](https://github.com/StefH/System.Linq.Dynamic.Core/issues/60) - Issue with nested Calls
 - [#57](https://github.com/StefH/System.Linq.Dynamic.Core/issues/57) - Issue finding indexer +fix
 - [#56](https://github.com/StefH/System.Linq.Dynamic.Core/pull/56) - Create .editorconfig contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#55](https://github.com/StefH/System.Linq.Dynamic.Core/pull/55) - Fix Nullable Enums from String contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#52](https://github.com/StefH/System.Linq.Dynamic.Core/issues/52) - Can I convert int to string type?
 - [#50](https://github.com/StefH/System.Linq.Dynamic.Core/issues/50) - Add functionality to optimize your queries using Linq.Expression.Optimizer +enhancement
 - [#48](https://github.com/StefH/System.Linq.Dynamic.Core/issues/48) - Add an overload to the "ToDynamicList" method which accepts a Type +enhancement
 - [#47](https://github.com/StefH/System.Linq.Dynamic.Core/pull/47) - * Add unit test and fix public methods access. contributed by ([jotab123](https://github.com/jotab123))
 - [#46](https://github.com/StefH/System.Linq.Dynamic.Core/issues/46) - Methods on type are not accessible error
 - [#45](https://github.com/StefH/System.Linq.Dynamic.Core/issues/45) - Take() and Skip() lose ElementType +fix
 - [#43](https://github.com/StefH/System.Linq.Dynamic.Core/issues/43) - Join with dependent subquery?
 - [#42](https://github.com/StefH/System.Linq.Dynamic.Core/issues/42) - Microsoft.EntityFrameworkCore.DynamicLinq - ToListAsync()?
 - [#41](https://github.com/StefH/System.Linq.Dynamic.Core/pull/41) - Separation of tokenization logic contributed by ([arespr](https://github.com/arespr))
 - [#40](https://github.com/StefH/System.Linq.Dynamic.Core/issues/40) - Add strong naming from library +enhancement
 - [#39](https://github.com/StefH/System.Linq.Dynamic.Core/pull/39) - Exception friendly Type loading contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#38](https://github.com/StefH/System.Linq.Dynamic.Core/pull/38) - Support more comparisons with strings contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#37](https://github.com/StefH/System.Linq.Dynamic.Core/pull/37) - Support strings as Enum Parameter Objects contributed by Jochen Kühner ([jogibear9988](https://github.com/jogibear9988))
 - [#36](https://github.com/StefH/System.Linq.Dynamic.Core/issues/36) - CreateClass Equivalent? +enhancement
 - [#35](https://github.com/StefH/System.Linq.Dynamic.Core/issues/35) - Compatibility with System.Linq.Dynamic.Library 
 - [#34](https://github.com/StefH/System.Linq.Dynamic.Core/issues/34) - Support for netcoreapp1.0?
 - [#32](https://github.com/StefH/System.Linq.Dynamic.Core/issues/32) - When same dynamic class is first used in Linq2Entities, it's reused for Linq2Sql +fix
 - [#31](https://github.com/StefH/System.Linq.Dynamic.Core/issues/31) - Group by multiple columns? +fix
 - [#30](https://github.com/StefH/System.Linq.Dynamic.Core/issues/30) - Move to .NET Core RTM
 - [#29](https://github.com/StefH/System.Linq.Dynamic.Core/issues/29) - An another project ?
 - [#28](https://github.com/StefH/System.Linq.Dynamic.Core/issues/28) - Dynamic Queries seem to lose "Include()"s
 - [#27](https://github.com/StefH/System.Linq.Dynamic.Core/issues/27) - UWP version
 - [#26](https://github.com/StefH/System.Linq.Dynamic.Core/issues/26) - Calling ToString on a nullable column throws error
 - [#25](https://github.com/StefH/System.Linq.Dynamic.Core/issues/25) - DynamicExpression gone in version 1.0.3.4
 - [#24](https://github.com/StefH/System.Linq.Dynamic.Core/issues/24) - FirstOrDefaultAsync method is missing
 - [#23](https://github.com/StefH/System.Linq.Dynamic.Core/issues/23) - Cannot work with property which in base class. +fix
 - [#22](https://github.com/StefH/System.Linq.Dynamic.Core/issues/22) - DynamicExpression accessibility +enhancement
 - [#21](https://github.com/StefH/System.Linq.Dynamic.Core/issues/21) - Question: why is Distinct not supported? +enhancement
 - [#20](https://github.com/StefH/System.Linq.Dynamic.Core/issues/20) - Can't install using nuget in Asp.Net 4.0 Web Pages project
 - [#19](https://github.com/StefH/System.Linq.Dynamic.Core/issues/19) - NotEqual filter not working with DateTime +fix
 - [#18](https://github.com/StefH/System.Linq.Dynamic.Core/issues/18) - SelectMany over an Array throws System.IndexOutOfRangeException +fix
 - [#17](https://github.com/StefH/System.Linq.Dynamic.Core/issues/17) - Windows 10 uwp support
 - [#16](https://github.com/StefH/System.Linq.Dynamic.Core/issues/16) - Add Paging support +enhancement
 - [#15](https://github.com/StefH/System.Linq.Dynamic.Core/issues/15) - Add Skip, Take to ExpressionParser +enhancement
 - [#14](https://github.com/StefH/System.Linq.Dynamic.Core/issues/14) - Ampersand can be used both as logical And or as vb-like concatenation operator +enhancement
 - [#13](https://github.com/StefH/System.Linq.Dynamic.Core/issues/13) - Add isnull sql function "isnull(a, b)" +enhancement
 - [#12](https://github.com/StefH/System.Linq.Dynamic.Core/issues/12) - parsing negative float or double with qualifier +enhancement
 - [#11](https://github.com/StefH/System.Linq.Dynamic.Core/issues/11) - IN does not support negative and parse of negative integers with qualifiers. +fix
 - [#10](https://github.com/StefH/System.Linq.Dynamic.Core/issues/10) - Support explicit integer qualifiers +enhancement
 - [#9](https://github.com/StefH/System.Linq.Dynamic.Core/issues/9) - Add Null-coalescing operator support +enhancement
 - [#8](https://github.com/StefH/System.Linq.Dynamic.Core/pull/8) - Remove useless dependences contributed by SilverFox ([yyjdelete](https://github.com/yyjdelete)) +enhancement
 - [#7](https://github.com/StefH/System.Linq.Dynamic.Core/issues/7) - Add SelectMany with resultSelector +enhancement
 - [#6](https://github.com/StefH/System.Linq.Dynamic.Core/issues/6) - Add support for dotnet5.4 framework +enhancement
 - [#5](https://github.com/StefH/System.Linq.Dynamic.Core/issues/5) - Only parameterless constructors and initializers are supported in LINQ to Entities +fix
 - [#4](https://github.com/StefH/System.Linq.Dynamic.Core/issues/4) - Illegal one-byte branch at position: 9. Requested branch was: 143
 - [#3](https://github.com/StefH/System.Linq.Dynamic.Core/issues/3) - Add "SelectMany" +enhancement
 - [#2](https://github.com/StefH/System.Linq.Dynamic.Core/issues/2) - UnitTest : GroupByAndSelect_TestDynamicSelectMember fails +fix
 - [#1](https://github.com/StefH/System.Linq.Dynamic.Core/issues/1) - SymbolTable.DoesMethodHaveParameterArray throws exception when accessing a dynamic created property

Commits: a02f3d64fa...a32f8327e3
