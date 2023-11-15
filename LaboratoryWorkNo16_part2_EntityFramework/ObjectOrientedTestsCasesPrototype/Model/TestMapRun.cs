using System;
using System.Collections.Generic;

namespace ObjectOrientedTestsCasesPrototype.Model;

public partial class TestMapRun
{
    public int RunId { get; set; }

    public string RunName { get; set; } = null!;

    public string? Comment { get; set; }

    public int RunOrderNumber { get; set; }

    public int? TargetTestMapId { get; set; }

    public virtual TestMap? TargetTestMap { get; set; }

    public virtual ICollection<TestCaseRun> TestCaseRuns { get; } = new List<TestCaseRun>();

    public virtual ICollection<TestMapRunInherition> TestMapRunInheritionContainerTestMapRuns { get; } = new List<TestMapRunInherition>();

    public virtual ICollection<TestMapRunInherition> TestMapRunInheritionHoldedTestMapRuns { get; } = new List<TestMapRunInherition>();
}
