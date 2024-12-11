# Delta
**Delta**는 WPF 환경에서 MVU(Model-View-Update) 패턴을 간결하고 직관적으로 구현할 수 있게 해주는 라이브러리입니다. React의 함수형 상태 관리(Hooks) 개념에서 영감을 받아 `useState`를 통한 상태 관리와, 선언형으로 UI를 정의하는 체인 메서드(Fluent) 스타일의 문법을 결합하였습니다. 이를 통해 복잡한 UI 로직을 단순하고 명확하게 표현하고, 효율적인 업데이트를 자동으로 처리할 수 있습니다.

# 특징
### MVU (Model-View-Update) 패턴 구현
- **Model**
    - React의 Hooks 개념을 참고하여 useState 형태의 상태 관리를 제공합니다.
    - 명령형 코드 없이, 상태 변화에 따른 UI 변경 사항을 선언적으로 표현할 수 있습니다
    <br/>예: var (count, setCount) = useState(0);
- **View**
    - WPF의 체인 메서드 스타일을 활용한 선언형 UI 구성 방식을 지원합니다.
    - 복잡한 XAML 대신 직관적인 C# 코드로 UI 계층을 표현함으로써, 유지보수성을 향상시킵니다.
    - 예:
        ```csharp
        var view = HStack(  
            Text($"Count: {count}"),
            Button("Increment")
            .OnClick(() => setCount(count + 1))
        );
        ```
- **Update**

    - Diffing 알고리즘을 적용하여 변경점만 효율적으로 업데이트합니다.
    - 노드 비교 → 속성 비교 → 컨트롤 비교 순으로 최소한의 렌더링만 수행하여 성능을 개선합니다.
# 예시 코드
```csharp
using Delta;

public class CounterComponent : Component
{
    protected override IVisual Render()
    {
        var (count, setCount) = useState(0);

        return HStack(
                        Text($"Count: {count}"),
                        Button("Increment")
                            .OnClick(() => setCount(count + 1)),
                        Button("Decrement")
                            .OnClick(() => setCount(count - 1))
                    );
    }
}
```
이 예제에서는 useState를 통해 상태를 관리하고, 버튼 클릭 시 새로운 상태를 반영합니다. Delta는 상태 변화를 감지하고, diffing을 통해 변경된 부분만 업데이트합니다.

# 시작하기
Template 설치
```
dotnet new install DeltaMVU.Template::0.1.0
```

# 기여하기
라이브러리에 대한 제안, 버그 제보, 개선사항 등은 언제나 환영합니다.
이슈 트래커를 통해 의견을 남겨주세요.
