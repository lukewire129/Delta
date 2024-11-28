using Delta.WPF;
using static Delta.WPF.Element;
namespace DeltaWPFSample.Components.MainLayout
{
    public class MainWindow : DeltaWindow
    {
        public override VisualNode Build()
            => Grid (
                        Button ()
                            .Content ("Initial Button")
                            .Width (100)
                            .Height (50)
                            .OnClick ((s, e) =>
                            {
                                // UI 업데이트 테스트
                                //UpdateUI ();
                            })
                            .SetProperty ("Grid.Row", 0), // 첫 번째 행에 배치
                        Input ()
                            .Text ("Enter your updated name")
                            .SetProperty ("Grid.Row", 1) // 두 번째 행에 배치
                   )
                   .Rows (50, 100);
    }
}