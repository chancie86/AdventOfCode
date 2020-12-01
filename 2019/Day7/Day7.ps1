param (
    $LogLevel = 1
)

$ErrorActionPreference = "Stop"

Import-Module (Join-Path $PSScriptRoot "..\Helpers\common.psm1") -Force
Import-Module (Join-Path $PSScriptRoot "intcode_computer.psm1") -Force

$inputData = @(3,8,1001,8,10,8,105,1,0,0,21,38,59,76,89,106,187,268,349,430,99999,3,9,1002,9,3,9,101,2,9,9,1002,9,4,9,4,9,99,3,9,1001,9,5,9,1002,9,5,9,1001,9,2,9,1002,9,3,9,4,9,99,3,9,1001,9,4,9,102,4,9,9,1001,9,3,9,4,9,99,3,9,101,4,9,9,1002,9,5,9,4,9,99,3,9,1002,9,3,9,101,5,9,9,1002,9,3,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,99,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,99)

$script:logLevel = $LogLevel

function Part1_Execute
{
    param (
        [int[]]
        $Program,

        [int[]]
        $PhaseSettings
    )
    
    $param = 0

    $PhaseSettings | % {
        $param = Run -Program $Program.Clone() -InputValues @($_, $param)
    }

    $param
}

function Part1_Tests
{
    $result = Part1_Execute -Program @(3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0) -PhaseSettings @(4,3,2,1,0)
    AssertEquals -Actual $result -Expected 43210

    $result = Part1_Execute -Program @(3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0) -PhaseSettings @(0,1,2,3,4)
    AssertEquals -Actual $result -Expected 54321

    $result = Part1_Execute -Program @(3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0) -PhaseSettings @(1,0,4,3,2)
    AssertEquals -Actual $result -Expected 65210
}

function IncrementPhaseSetting
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $PhaseSetting
    )

    do
    {
        # Phase settings are a 5 integer array with max digit value of 4
        $incrementNext = $false
        $i = 4

        # Increment from right to left and increment the next value if we roll over.
        do
        {
            $incrementNext = $PhaseSetting[$i] -eq 4 -and $i -gt 0
            $PhaseSetting[$i] = ($PhaseSetting[$i] + 1) % 5
            $i--
        } while ($incrementNext)

        $hasAllDigits = $PhaseSetting -contains 0 `
            -and $PhaseSetting -contains 1 `
            -and $PhaseSetting -contains 2 `
            -and $PhaseSetting -contains 3 `
            -and $PhaseSetting -contains 4
    } while (-not($hasAllDigits))

    $PhaseSetting
}

function Part1
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program
    )

    $currentPhaseSetting = IncrementPhaseSetting -PhaseSetting @(0,0,0,0,0)
    $maxPhaseSetting = $currentPhaseSetting.Clone()

    do
    {
        Log-Verbose -Message "Trying $($currentPhaseSetting -join ',')" -Level 5

        $lastFirstDigit = $currentPhaseSetting[0]
        $result = Part1_Execute -Program $inputData -PhaseSettings $currentPhaseSetting
        
        if ($result -ge $maxValue)
        {
            $maxValue = $result
            $maxPhaseSetting = $currentPhaseSetting.Clone()

            Write-Host "Updating max phase setting: $($maxPhaseSetting -join ',') results in $maxValue"
        }

        $currentPhaseSetting = IncrementPhaseSetting -PhaseSetting $currentPhaseSetting
    }
    while ($lastFirstDigit -le $currentPhaseSetting[0])

    Write-Host "Max phase setting: $($maxPhaseSetting -join ','), Signal value: $maxValue"
}

Part1_Tests
Part1 -Program $inputData