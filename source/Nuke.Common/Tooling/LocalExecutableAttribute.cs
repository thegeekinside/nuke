// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common.Execution;

namespace Nuke.Common.Tooling
{
    /// <summary>
    ///     Injects a delegate for process execution. The path relative to the root directory is passed as constructor argument.
    /// </summary>
    /// <example>
    ///     <code>
    /// [LocalExecutable("./tools/custom.exe")] readonly Tool Custom;
    /// Target FooBar => _ => _
    ///     .Executes(() =>
    ///     {
    ///         var output = Custom("test");
    ///     });
    ///     </code>
    /// </example>
    public class LocalExecutableAttribute : InjectionAttributeBase
    {
        private readonly string _rootDirectoryRelativePath;

        public LocalExecutableAttribute(string rootDirectoryRelativePath)
        {
            _rootDirectoryRelativePath = rootDirectoryRelativePath;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            return ToolResolver.GetLocalTool(_rootDirectoryRelativePath);
        }
    }
}
