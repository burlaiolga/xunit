﻿using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

#if XUNIT_FRAMEWORK
namespace Xunit.Sdk
#else
using Xunit.Sdk;

namespace Xunit
#endif
{
	/// <summary>
	/// Default implementation of <see cref="ITestAssemblyMessage"/> and <see cref="IExecutionMessage"/>.
	/// </summary>
#if XUNIT_FRAMEWORK
	public class TestAssemblyMessage : ITestAssemblyMessage, IExecutionMessage
#else
	public class TestAssemblyMessage : LongLivedMarshalByRefObject, ITestAssemblyMessage, IExecutionMessage
#endif
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TestAssemblyMessage"/> class.
		/// </summary>
		public TestAssemblyMessage(
			IEnumerable<ITestCase> testCases,
			ITestAssembly testAssembly)
		{
			Guard.ArgumentNotNull(nameof(testCases), testCases);
			Guard.ArgumentNotNull(nameof(testAssembly), testAssembly);

			TestAssembly = testAssembly;
			TestCases = testCases.ToList();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TestAssemblyMessage"/> class.
		/// </summary>
		internal TestAssemblyMessage(
			ITestCase testCase,
			ITestAssembly testAssembly)
		{
			Guard.ArgumentNotNull(nameof(testCase), testCase);
			Guard.ArgumentNotNull(nameof(testAssembly), testAssembly);

			TestAssembly = testAssembly;
			TestCases = new ITestCase[] { testCase };
		}

		/// <inheritdoc/>
		public ITestAssembly TestAssembly { get; set; }

		/// <inheritdoc/>
		public IEnumerable<ITestCase> TestCases { get; }
	}
}
