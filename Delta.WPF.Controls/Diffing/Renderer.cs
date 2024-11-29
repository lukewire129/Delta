using Delta.WPF.Controls.Base;
using SkiaSharp;

namespace Delta.WPF.Controls.Diffing
{
    public class Renderer
    {
        public void ApplyDiff(SKCanvas canvas, VisualNode root, List<DiffOperation> operations)
        {
            foreach (var operation in operations)
            {
                switch (operation.Type)
                {
                    case DiffOperationType.Add:
                        operation.NewNode?.Render (canvas, new SKRect (0, 0, root.Width, root.Height));
                        break;

                    case DiffOperationType.Remove:
                        // Remove는 SkiaSharp에서 별도 처리 필요 없음
                        break;

                    case DiffOperationType.Replace:
                        operation.OldNode?.Render (canvas, new SKRect (0, 0, root.Width, root.Height)); // 기존 제거
                        operation.NewNode?.Render (canvas, new SKRect (0, 0, root.Width, root.Height)); // 새로운 추가
                        break;

                    case DiffOperationType.UpdateProperty:
                        // 속성 업데이트 처리
                        Console.WriteLine ($"Property {operation.PropertyKey} updated to {operation.NewValue}");
                        break;
                }
            }
        }
    }
}
