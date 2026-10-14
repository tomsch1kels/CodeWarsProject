// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Codewars.", Scope = "module")]
[assembly: SuppressMessage("Performance", "CA1814", Justification = "Multidimensional array needed", Scope = "module")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented", Justification = "Too Muh ork", Scope = "module")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Static extension class created", Scope = "module")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "Doesnt work for tests", Scope = "module")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Only for external APIs", Scope = "module")]
