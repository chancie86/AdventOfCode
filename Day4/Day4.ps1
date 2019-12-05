$ErrorActionPreference = "Stop"

$range = 236491..713787

function MakeAscendingNumbers
{
    param (
        [int]
        $Number
    )

    $digits = $Number.ToString().ToCharArray() | % { [int]::Parse($_) }
    $rewrite = $false

    for ($i = 1; $i -lt $digits.Length; $i++)
    {
        $currentDigit = $digits[$i]
        $previousDigit = $digits[$i-1]

        if ($rewrite -or ($currentDigit -lt $previousDigit))
        {
            $digits[$i] = $previousDigit
            $rewrite = $true
        }
    }

    [int]::Parse([string]::Join("", $digits))
}

function HasDoubleDigits
{
    param(
        [int]
        $Number
    )

    $Number.ToString() -match "(\d)(\1)"
}

function HasDoubleDigitsExact
{
    param(
        [int]
        $Number
    )

    $regex = [regex]"(\d)\1+"
    $matches = $regex.Matches($Number.ToString())
    ($matches | ? { $_.Value.Length -eq 2 }) -ne $null
}

function FindMatch
{
    param (
        [int[]]
        $Range,

        [switch]
        $HasDoubleDigitsExact
    )

    $validNumbers = New-Object -TypeName System.Collections.ArrayList

    $biggestNumber = $Range[$Range.Length-1]

    for ($number = (MakeAscendingNumbers -Number $Range[0]); $number -le $biggestNumber; $number++)
    {
        if (($number % 10) -eq 0)
        {
            $number = MakeAscendingNumbers -Number $number
            if ($number -gt $biggestNumber)
            {
                break
            }
        }

        if ($HasDoubleDigitsExact)
        {
            if (-not(HasDoubleDigitsExact -Number $number))
            {
                continue
            }
        }
        elseif (-not(HasDoubleDigits -Number $number))
        {
            continue
        }
    
        $validNumbers.Add($number) | Out-Null
        Write-Verbose $number
    }

    $validNumbers
}

$answer = FindMatch -Range $range
Write-Host "Part 1: $($answer.Count)"

$answer = FindMatch -Range $answer -HasDoubleDigitsExact
Write-Host "Part 2: $($answer.Count)"