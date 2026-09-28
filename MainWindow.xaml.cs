using Infragistics.Controls.Maps;
using System.Windows;

namespace OrgChartSpanOfControl;

public partial class MainWindow : Window
{
    private int _threshold = 3;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        ThresholdTextBox.Text = _threshold.ToString();
    }

    /// <summary>。
    /// ノードがアタッチされるたびに、対応する社員データのDirectReports.Countを
    /// しきい値と比較し、超えていれば警告スタイルを割り当てる。
    /// </summary>
    private void OrgChart_NodeControlAttachedEvent(object sender, OrgChartNodeEventArgs e)
    {
        ApplyStyle(e.Node.Node);
    }

    private void ApplyStyle(OrgChartNode node)
    {
        if (node.Data is not Employee employee)
        {
            return;
        }

        node.Style = employee.DirectReports.Count > _threshold
            ? (Style)Resources["OverloadedManagerNodeStyle"]
            : (Style)Resources["NormalNodeStyle"];
    }

    /// <summary>
    /// しきい値を変更した際に、画面上の判定をやり直す。
    /// ItemsSourceを一度nullにしてから再設定することでツリー全体を
    /// 作り直し、ルートを含む全ノードについてNodeControlAttachedEventを
    /// 再度発生させる。
    /// (ツリーが作り直されるため、ユーザーが個別に展開/折りたたみしていた
    /// 状態はリセットされる点に注意)
    /// </summary>
    private void ApplyThresholdButton_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(ThresholdTextBox.Text, out var threshold) || threshold < 0)
        {
            MessageBox.Show("しきい値は0以上の整数で入力してください。");
            return;
        }

        _threshold = threshold;

        var items = OrgChart.ItemsSource;
        OrgChart.ItemsSource = null;
        OrgChart.ItemsSource = items;
    }
}
