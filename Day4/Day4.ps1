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

    $Number.ToString() -match "([0-9])\1+"
}

$validNumbers = New-Object -TypeName System.Collections.ArrayList

$biggestNumber = $range[$range.Length-1]

for ($number = (MakeAscendingNumbers -Number $range[0]); $number -le $biggestNumber; $number++)
{
    if (($number % 10) -eq 0)
    {
        $number = MakeAscendingNumbers -Number $number
        if ($number -gt $biggestNumber)
        {
            break
        }
    }

    if (-not(HasDoubleDigits -Number $number))
    {
        continue
    }
    
    $validNumbers.Add($number) | Out-Null
    Write-Verbose $number
}

return $validNumbers.Count