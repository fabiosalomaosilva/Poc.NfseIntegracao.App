# Configuração de Versionamento
# Este arquivo define a versão atual da aplicação

[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseDeclaredVarsMoreThanAssignments', '')]
param()

# Versão atual da aplicação (Semantic Versioning)
$Script:CurrentVersion = "1.0.0"

# Função para obter a versão atual
function Get-AppVersion {
    return $Script:CurrentVersion
}

# Função para incrementar versão
function Update-AppVersion {
    param(
        [Parameter(Mandatory=$true)]
        [ValidateSet("Major", "Minor", "Patch")]
        [string]$Type
    )
    
    $version = [System.Version]::Parse($Script:CurrentVersion)
    
    switch ($Type) {
        "Major" { 
            $newVersion = [System.Version]::new($version.Major + 1, 0, 0)
        }
        "Minor" { 
            $newVersion = [System.Version]::new($version.Major, $version.Minor + 1, 0)
        }
        "Patch" { 
            $newVersion = [System.Version]::new($version.Major, $version.Minor, $version.Build + 1)
        }
    }
    
    $Script:CurrentVersion = $newVersion.ToString()
    
    # Atualiza este arquivo
    $content = Get-Content $PSCommandPath
    $content = $content -replace 'CurrentVersion = "[\d\.]+"', "CurrentVersion = `"$($Script:CurrentVersion)`""
    Set-Content -Path $PSCommandPath -Value $content -Encoding UTF8
    
    Write-Host "Versão atualizada para: $($Script:CurrentVersion)" -ForegroundColor Green
    return $Script:CurrentVersion
}

# Função para criar release com a versão atual
function New-AppRelease {
    param(
        [switch]$CreateTag,
        [switch]$IncrementPatch
    )
    
    if ($IncrementPatch) {
        Update-AppVersion -Type "Patch"
    }
    
    $version = Get-AppVersion
    
    # Executa o script de criação de release
    $createReleaseScript = Join-Path $PSScriptRoot "Create-Release.ps1"
    
    if (Test-Path $createReleaseScript) {
        if ($CreateTag) {
            & $createReleaseScript -Version $version -CreateTag
        } else {
            & $createReleaseScript -Version $version
        }
    } else {
        Write-Error "Script Create-Release.ps1 não encontrado!"
    }
}

# Exporta as funções se o módulo for importado
Export-ModuleMember -Function Get-AppVersion, Update-AppVersion, New-AppRelease

# Se executado diretamente, mostra informações
if ($MyInvocation.ScriptName -eq $PSCommandPath) {
    Write-Host "🔢 Versão Atual da Aplicação: $($Script:CurrentVersion)" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Comandos disponíveis:" -ForegroundColor Yellow
    Write-Host "• Get-AppVersion                    - Obtém a versão atual" -ForegroundColor White
    Write-Host "• Update-AppVersion -Type Major     - Incrementa versão major (x.0.0)" -ForegroundColor White
    Write-Host "• Update-AppVersion -Type Minor     - Incrementa versão minor (0.x.0)" -ForegroundColor White
    Write-Host "• Update-AppVersion -Type Patch     - Incrementa versão patch (0.0.x)" -ForegroundColor White
    Write-Host "• New-AppRelease                    - Cria release com versão atual" -ForegroundColor White
    Write-Host "• New-AppRelease -IncrementPatch    - Incrementa patch e cria release" -ForegroundColor White
    Write-Host "• New-AppRelease -CreateTag         - Cria release e tag Git" -ForegroundColor White
    Write-Host ""
    Write-Host "Para usar essas funções, importe este arquivo:" -ForegroundColor Green
    Write-Host ". .\Version.ps1" -ForegroundColor White
}
