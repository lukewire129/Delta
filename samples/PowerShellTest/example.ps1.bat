@chcp 65001
@echo 파워쉘7이 설치되야 합니다. https://github.com/PowerShell/PowerShell/releases/tag/v7.4.6

@pwsh -c "((cat -raw '%~0') -Split '#'+'split')[1..2] | iex"
@pause && exit

#split

$_ = Install-Package DeltaMVU -v -Force -Scope CurrentUser
$_ = Add-Type -PassThru -AssemblyName ((Get-ChildItem -Recurse (Split-Path (Get-Package DeltaMVU).Source)).FullName |? {$_ -like "*net8*.dll"})

#split

Using Namespace Delta.WPF
Class Comp : Component {
    [IElement] Render() {
        $script:count1, $script:setCount1 = $this.UseState[int](0)[0..1]
        $script:count2, $script:setCount2 = $this.UseState[int](0)[0..1]
        return [Component]::VStack(
            [Component]::Button("Count1: " + $script:count1, { param($s, $e); $script:setCount1.Invoke($count1 + 1) }),
            [Component]::Button("Reset1", { param($s, $e); $script:setCount1.Invoke(0) }),
            [Component]::Button("Count2: " + $script:count2, { param($s, $e); $script:setCount2.Invoke($count2 + 1) }),
            [Component]::Button("Reset2", { param($s, $e); $script:setCount2.Invoke(0) })
        )
    }
}
$w = New-Object System.Windows.Window -Property @{ Width = 320; Height = 240 }
[ApplicationRoot]::Initialize([Comp]::new(), $w)
[System.Windows.Application]::new().Run($w)
