namespace OrgChartSpanOfControl;

/// <summary>
/// デモ用の組織階層データを構築する。
/// </summary>
public static class SampleOrgChartData
{
    public static Employee CreateRoot()
    {
        var ceo = new Employee { Name = "山田 太郎", Title = "CEO" };

        var salesDirector = new Employee { Name = "佐藤 花子", Title = "営業部長" };
        salesDirector.DirectReports.Add(new Employee { Name = "鈴木 一郎", Title = "営業マネージャー" });
        salesDirector.DirectReports.Add(new Employee { Name = "高橋 次郎", Title = "営業マネージャー" });
        salesDirector.DirectReports.Add(new Employee { Name = "田中 三郎", Title = "営業マネージャー" });
        salesDirector.DirectReports.Add(new Employee { Name = "清水 大輔", Title = "営業マネージャー" });


        var devDirector = new Employee { Name = "伊藤 健", Title = "開発部長" };

        var frontendLeader = new Employee { Name = "渡辺 誠", Title = "フロントエンドリーダー" };
        frontendLeader.DirectReports.Add(new Employee { Name = "加藤 亮", Title = "エンジニア" });
        frontendLeader.DirectReports.Add(new Employee { Name = "吉田 直樹", Title = "エンジニア" });
        frontendLeader.DirectReports.Add(new Employee { Name = "山本 拓也", Title = "エンジニア" });
        frontendLeader.DirectReports.Add(new Employee { Name = "中村 隆", Title = "エンジニア" });
        frontendLeader.DirectReports.Add(new Employee { Name = "岡田 健二", Title = "エンジニア" });

        var backendLeader = new Employee { Name = "小林 修", Title = "バックエンドリーダー" };
        backendLeader.DirectReports.Add(new Employee { Name = "藤田 隼人", Title = "エンジニア" });
        backendLeader.DirectReports.Add(new Employee { Name = "石川 大和", Title = "エンジニア" });

        devDirector.DirectReports.Add(frontendLeader);
        devDirector.DirectReports.Add(backendLeader);

        var hrDirector = new Employee { Name = "木村 恵", Title = "人事部長" };
        hrDirector.DirectReports.Add(new Employee { Name = "林 明美", Title = "採用担当" });

        ceo.DirectReports.Add(salesDirector);
        ceo.DirectReports.Add(devDirector);
        ceo.DirectReports.Add(hrDirector);

        return ceo;
    }
}
