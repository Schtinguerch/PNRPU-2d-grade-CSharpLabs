using System;
using System.Collections.Generic;

namespace ObjectOrientedTestsCasesPrototype.Model;

public partial class TestMapRunInherition
{
    public int InheritionId { get; set; }

    public int ContainerTestMapRunId { get; set; }

    public int HoldedTestMapRunId { get; set; }

    public virtual TestMapRun ContainerTestMapRun { get; set; } = null!;

    public virtual TestMapRun HoldedTestMapRun { get; set; } = null!;
}
