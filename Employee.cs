using System.Collections.ObjectModel;

namespace OrgChartSpanOfControl;

/// <summary>
/// 組織図の1ノードに対応する社員データ。
/// DirectReports(直属の部下)の数が「管理限界(Span of Control)」の判定材料になる。
/// </summary>
public class Employee
{
    public required string Name { get; init; }
    public required string Title { get; init; }
    public ObservableCollection<Employee> DirectReports { get; } = new();
}
