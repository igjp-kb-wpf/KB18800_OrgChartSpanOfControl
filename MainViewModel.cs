namespace OrgChartSpanOfControl;

/// <summary>
/// ルート社員(CEO)を1件だけ含むコレクションを公開する、ごく簡単なViewModel。
/// xamOrgChartのItemsSourceはIEnumerableを受け取れるため、ルートが1人でも
/// 単一要素のリストとして渡す。
/// </summary>
public class MainViewModel
{
    public IReadOnlyList<Employee> RootEmployees { get; } = new[] { SampleOrgChartData.CreateRoot() };
}
