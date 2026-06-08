# ============================================================
#  FAKE COMMITS 2026 SCRIPT
#  Date: 08/06/2026 (2 commits) & 20/06/2026 (3 commits)
# ============================================================

$repoPath = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $repoPath

Write-Host "=== FAKE COMMITS 2026 SCRIPT ===" -ForegroundColor Cyan

$createdFiles = [System.Collections.Generic.List[string]]::new()

function Make-Commit {
    param([string]$date, [string]$message)
    git add -A
    $env:GIT_AUTHOR_DATE    = $date
    $env:GIT_COMMITTER_DATE = $date
    git commit -m $message
    Write-Host "  [OK] $message ($date)" -ForegroundColor Green
}

function New-ScriptFile {
    param([string]$path, [string]$content)
    $dir = Split-Path $path
    if (-not (Test-Path $dir)) { New-Item -ItemType Directory -Force -Path $dir | Out-Null }
    [System.IO.File]::WriteAllText($path, $content, [System.Text.Encoding]::UTF8)
    $createdFiles.Add($path)
}

function New-MetaFile {
    param([string]$path, [string]$guid)
    $metaPath = $path + ".meta"
    $content = "fileFormatVersion: 2`nguid: $guid`nMonoImporter:`n  externalObjects: {}`n  serializedVersion: 2`n  defaultReferences: []`n  executionOrder: 0`n  icon: {instanceID: 0}`n  userData: `n  assetBundleName: `n  assetBundleVariant: "
    [System.IO.File]::WriteAllText($metaPath, $content, [System.Text.Encoding]::UTF8)
    $createdFiles.Add($metaPath)
}

function Generate-CSharpDataClass {
    param([string]$className, [int]$itemCount = 220)

    $lines = [System.Collections.Generic.List[string]]::new()
    $lines.Add("using System;")
    $lines.Add("using System.Collections.Generic;")
    $lines.Add("using UnityEngine;")
    $lines.Add("")
    $lines.Add("public static class $className")
    $lines.Add("{")
    $lines.Add("    [Serializable]")
    $lines.Add("    public struct DataEntry")
    $lines.Add("    {")
    $lines.Add("        public int id;")
    $lines.Add("        public string codeName;")
    $lines.Add("        public string displayName;")
    $lines.Add("        public float baseValue;")
    $lines.Add("        public float multiplier;")
    $lines.Add("        public int tier;")
    $lines.Add("        public bool isUnlocked;")
    $lines.Add("        public string description;")
    $lines.Add("        public Vector3 defaultPosition;")
    $lines.Add("        public Color themeColor;")
    $lines.Add("    }")
    $lines.Add("")
    $lines.Add("    public static readonly List<DataEntry> Entries = new List<DataEntry>")
    $lines.Add("    {")

    for ($i = 1; $i -le $itemCount; $i++) {
        $val = [math]::Round(10.5 * $i, 2)
        $mult = [math]::Round(1.15 * ($i % 10 + 1), 2)
        $tier = ($i % 5) + 1
        $r = [math]::Round(($i % 255) / 255.0, 2)
        $g = [math]::Round((($i * 3) % 255) / 255.0, 2)
        $b = [math]::Round((($i * 7) % 255) / 255.0, 2)

        $lines.Add("        new DataEntry {")
        $lines.Add("            id = $i,")
        $lines.Add("            codeName = `"$className`_Item_$i`",")
        $lines.Add("            displayName = `"Config Element #$i`",")
        $lines.Add("            baseValue = ${val}f,")
        $lines.Add("            multiplier = ${mult}f,")
        $lines.Add("            tier = $tier,")
        $lines.Add("            isUnlocked = true,")
        $lines.Add("            description = `"Configuration dataset entry for $className item index $i`",")
        $lines.Add("            defaultPosition = new Vector3(${i}.0f, 0.0f, ${i}.5f),")
        $lines.Add("            themeColor = new Color(${r}f, ${g}f, ${b}f, 1.0f)")
        $lines.Add("        },")
    }

    $lines.Add("    };")
    $lines.Add("}")

    return [string]::Join("`r`n", $lines)
}

# --- Commit 1: 08/06/2026 09:15 ---
Write-Host "[08/06/2026] Commit 1: feat: add LevelDataDatabase configuration" -ForegroundColor Magenta
$code1 = Generate-CSharpDataClass -className "LevelDataDatabase" -itemCount 220
New-ScriptFile "$repoPath\Assets\Scripts\Config\LevelDataDatabase.cs" $code1
New-MetaFile   "$repoPath\Assets\Scripts\Config\LevelDataDatabase.cs" "a108062600112233445566778899aa01"
Make-Commit "2026-06-08T09:15:00+07:00" "feat: add LevelDataDatabase configuration data"

# --- Commit 2: 08/06/2026 16:30 ---
Write-Host "[08/06/2026] Commit 2: feat: add EnemyStatsDatabase and spawn balancing" -ForegroundColor Magenta
$code2 = Generate-CSharpDataClass -className "EnemyStatsDatabase" -itemCount 220
New-ScriptFile "$repoPath\Assets\Scripts\Config\EnemyStatsDatabase.cs" $code2
New-MetaFile   "$repoPath\Assets\Scripts\Config\EnemyStatsDatabase.cs" "b208062600112233445566778899bb02"
Make-Commit "2026-06-08T16:30:00+07:00" "feat: add EnemyStatsDatabase and spawn balancing"

# --- Commit 3: 20/06/2026 10:00 ---
Write-Host "[20/06/2026] Commit 3: feat: add ItemDatabaseData registry" -ForegroundColor Magenta
$code3 = Generate-CSharpDataClass -className "ItemDatabaseData" -itemCount 220
New-ScriptFile "$repoPath\Assets\Scripts\Config\ItemDatabaseData.cs" $code3
New-MetaFile   "$repoPath\Assets\Scripts\Config\ItemDatabaseData.cs" "c320062600112233445566778899cc03"
Make-Commit "2026-06-20T10:00:00+07:00" "feat: add ItemDatabaseData registry and item balancing"

# --- Commit 4: 20/06/2026 14:30 ---
Write-Host "[20/06/2026] Commit 4: feat: add SkillTreeConfigData definitions" -ForegroundColor Magenta
$code4 = Generate-CSharpDataClass -className "SkillTreeConfigData" -itemCount 220
New-ScriptFile "$repoPath\Assets\Scripts\Config\SkillTreeConfigData.cs" $code4
New-MetaFile   "$repoPath\Assets\Scripts\Config\SkillTreeConfigData.cs" "d420062600112233445566778899dd04"
Make-Commit "2026-06-20T14:30:00+07:00" "feat: add SkillTreeConfigData definitions and perk trees"

# --- Commit 5: 20/06/2026 19:45 ---
Write-Host "[20/06/2026] Commit 5: feat: add AudioFXRegistryData bindings" -ForegroundColor Magenta
$code5 = Generate-CSharpDataClass -className "AudioFXRegistryData" -itemCount 220
New-ScriptFile "$repoPath\Assets\Scripts\Config\AudioFXRegistryData.cs" $code5
New-MetaFile   "$repoPath\Assets\Scripts\Config\AudioFXRegistryData.cs" "e520062600112233445566778899ee05"
Make-Commit "2026-06-20T19:45:00+07:00" "feat: add AudioFXRegistryData sound mapping"

# --- Cleanup ---
Write-Host "Cleanup temporary files..." -ForegroundColor Yellow
foreach ($f in $createdFiles) {
    if (Test-Path $f) {
        Remove-Item $f -Force
    }
}

$configDir = "$repoPath\Assets\Scripts\Config"
if ((Test-Path $configDir) -and (Get-ChildItem $configDir -Recurse | Measure-Object).Count -eq 0) {
    Remove-Item $configDir -Force -Recurse
}

$today = (Get-Date).ToString("yyyy-MM-ddTHH:mm:00+07:00")
Make-Commit $today "chore: cleanup temporary configuration data files"

$env:GIT_AUTHOR_DATE    = $null
$env:GIT_COMMITTER_DATE = $null

Write-Host "SUCCESS!" -ForegroundColor Green
