using Delta;
using Delta.WPF;
using System.Windows;

namespace DeltaWPFSample.Components.MainLayout
{
    public class MainWindow : Window
    {
        private VirtualNode _currentVirtualNode;
        public MainWindow()
        {
            // 초기 VirtualNode 상태
            _currentVirtualNode = Markup.Grid ()
             .RowDefinition (Markup.Star ())     // 첫 번째 행: Star 크기
             .RowDefinition (50.0)             // 두 번째 행: 고정 50px
             .Children (
                 Markup.Button ()
                     .Content ("Initial Button")
                     .Width (100)
                     .Height (50)
                     .OnClick ((s,e) =>
                     {
                         // UI 업데이트 테스트
                         UpdateUI ();
                     })
                     .SetProperty ("Grid.Row", 0), // 첫 번째 행에 배치
                 Markup.TextBox ()
                     .Text ("Enter your updated name")
                     .SetProperty ("Grid.Row", 1) // 두 번째 행에 배치
             );

            // 초기 UI 렌더링
            this.Content = MarkupBuilder.Build (_currentVirtualNode);
        }

        private void UpdateUI()
        {
            // 새로운 VirtualNode 생성
            var newVirtualNode = Markup.Grid ()
                .RowDefinition (Markup.Star ())     // 첫 번째 행: Star 크기
                .RowDefinition (Markup.Star ())     // 첫 번째 행: Star 크기
                .RowDefinition (50.0)             // 두 번째 행: 고정 50px
                .Children (
                    Markup.Button ()
                        .Content ("Updated Button")
                        .Width (150)
                        .Height (60)
                        .SetProperty ("Grid.Row", 0), // 첫 번째 행에 배치
                     Markup.Button ()
                        .Content ("Updated Button!!")
                        .Width (150)
                        .Height (60)
                        .SetProperty ("Grid.Row", 1), // 첫 번째 행에 배치
                    Markup.TextBox ()
                        .Text ("Enter your updated name")
                        .SetProperty ("Grid.Row", 2)
                );

            // Diff 계산 및 적용
            var diffOperations = DiffEngine.Diff (_currentVirtualNode, newVirtualNode);

            if (this.Content is FrameworkElement rootElement)
            {
                RenderingEngine.ApplyDiff (rootElement, diffOperations);
            }

            // 현재 VirtualNode 상태 업데이트
            _currentVirtualNode = newVirtualNode;
        }
    }
}