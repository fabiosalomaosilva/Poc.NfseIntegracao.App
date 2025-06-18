# Script para criar uma release local da aplicação
# Uso: .\Create-Release.ps1 -Version "1.0.0" [-CreateTag]

param(
    [Parameter(Mandatory=$true)]
    [string]$Version,
    
    [Parameter(Mandatory=$false)]
    [switch]$CreateTag,
    
    [Parameter(Mandatory=$false)]
    [string]$Configuration = "Release"
)

# Configurações
$ProjectPath = "Poc.NfseIntegracao.App\Poc.NfseIntegracao.App.csproj"
$AppName = "Poc.NfseIntegracao.App"
$OutputDir = ".\release-output"
$PublishDir = ".\publish"

Write-Host "🚀 Iniciando criação da release v$Version" -ForegroundColor Green
Write-Host "================================================" -ForegroundColor Green

try {
    # Limpa diretórios anteriores
    Write-Host "🧹 Limpando diretórios anteriores..." -ForegroundColor Yellow
    if (Test-Path $OutputDir) {
        Remove-Item $OutputDir -Recurse -Force
    }
    if (Test-Path $PublishDir) {
        Remove-Item $PublishDir -Recurse -Force
    }

    # Verifica se o projeto existe
    if (-not (Test-Path $ProjectPath)) {
        throw "Projeto não encontrado: $ProjectPath"
    }

    # Restaura dependências
    Write-Host "📦 Restaurando dependências..." -ForegroundColor Yellow
    dotnet restore $ProjectPath
    if ($LASTEXITCODE -ne 0) {
        throw "Falha ao restaurar dependências"
    }

    # Build da aplicação
    Write-Host "🔨 Fazendo build da aplicação..." -ForegroundColor Yellow
    dotnet build $ProjectPath --configuration $Configuration --no-restore --verbosity minimal
    if ($LASTEXITCODE -ne 0) {
        throw "Falha no build da aplicação"
    }

    # Publica a aplicação
    Write-Host "📋 Publicando aplicação..." -ForegroundColor Yellow
    dotnet publish $ProjectPath `
        --configuration $Configuration `
        --output $PublishDir `
        --no-build `
        --verbosity minimal `
        --self-contained false `
        --runtime win-x64
    if ($LASTEXITCODE -ne 0) {
        throw "Falha na publicação da aplicação"
    }

    # Cria diretório de release
    Write-Host "📁 Criando pacote de release..." -ForegroundColor Yellow
    New-Item -ItemType Directory -Path $OutputDir -Force | Out-Null

    # Copia arquivos publicados
    Copy-Item -Path "$PublishDir\*" -Destination $OutputDir -Recurse -Force

    # Cria arquivo ZIP
    $ZipFileName = "$AppName-v$Version.zip"
    Write-Host "🎁 Criando arquivo ZIP: $ZipFileName" -ForegroundColor Yellow
    Compress-Archive -Path "$OutputDir\*" -DestinationPath $ZipFileName -Force

    # Gera informações da release
    $ReleaseInfo = @"
$AppName v$Version
============================

Data da Release: $(Get-Date -Format "dd/MM/yyyy HH:mm:ss")
Configuração: $Configuration
Plataforma: Windows x64
.NET Version: 9.0

Arquivos incluídos:
"@

    Get-ChildItem $OutputDir -Recurse -File | ForEach-Object {
        $RelativePath = $_.FullName.Replace("$((Get-Item $OutputDir).FullName)\", "")
        $ReleaseInfo += "`n- $RelativePath ($([math]::Round($_.Length / 1KB, 2)) KB)"
    }

    $ReleaseInfo += @"

Requisitos do Sistema:
- Windows 10 ou superior
- .NET 9.0 Runtime

Instruções de Instalação:
1. Extraia o arquivo ZIP em uma pasta de sua escolha
2. Execute o arquivo $AppName.exe
3. Se necessário, instale o .NET 9.0 Runtime

Estrutura de Arquivos:
📁 Aplicação Principal
  └── $AppName.exe         # Executável principal
  └── $AppName.dll         # Biblioteca da aplicação
  └── Newtonsoft.Json.dll  # Biblioteca JSON
  └── *.json               # Arquivos de configuração
  └── 📁 XSDs/             # Schemas de validação XML

"@

    # Salva informações da release
    $ReleaseInfo | Out-File -FilePath "Release-Info-v$Version.txt" -Encoding UTF8

    # Cria tag Git se solicitado
    if ($CreateTag) {
        Write-Host "🏷️ Criando tag Git..." -ForegroundColor Yellow
        $TagName = "v$Version"
        
        # Verifica se a tag já existe
        $ExistingTag = git tag -l $TagName
        if ($ExistingTag) {
            Write-Host "⚠️ Tag $TagName já existe. Removendo..." -ForegroundColor Yellow
            git tag -d $TagName
        }
        
        # Cria a nova tag
        git tag -a $TagName -m "Release version $Version"
        Write-Host "✅ Tag $TagName criada com sucesso!" -ForegroundColor Green
        Write-Host "💡 Para enviar a tag para o repositório remoto, execute:" -ForegroundColor Cyan
        Write-Host "   git push origin $TagName" -ForegroundColor White
    }

    # Resumo final
    Write-Host "`n✅ Release criada com sucesso!" -ForegroundColor Green
    Write-Host "=====================================`n" -ForegroundColor Green
    
    Write-Host "📊 Resumo da Release:" -ForegroundColor Cyan
    Write-Host "- Versão: v$Version" -ForegroundColor White
    Write-Host "- Arquivo ZIP: $ZipFileName" -ForegroundColor White
    Write-Host "- Tamanho: $([math]::Round((Get-Item $ZipFileName).Length / 1MB, 2)) MB" -ForegroundColor White
    Write-Host "- Arquivo de informações: Release-Info-v$Version.txt" -ForegroundColor White
    
    if ($CreateTag) {
        Write-Host "- Tag Git: v$Version (criada localmente)" -ForegroundColor White
    }

    Write-Host "`n📝 Próximos passos:" -ForegroundColor Cyan
    Write-Host "1. Teste a aplicação extraindo e executando o ZIP" -ForegroundColor White
    Write-Host "2. Se estiver tudo OK, envie a tag para ativar o GitHub Actions:" -ForegroundColor White
    Write-Host "   git push origin v$Version" -ForegroundColor Yellow
    Write-Host "3. O GitHub Actions criará automaticamente uma release pública" -ForegroundColor White

}
catch {
    Write-Host "`n❌ Erro durante a criação da release:" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    exit 1
}
finally {
    # Limpa diretórios temporários
    if (Test-Path $PublishDir) {
        Remove-Item $PublishDir -Recurse -Force -ErrorAction SilentlyContinue
    }
}

Write-Host "`n🎉 Processo concluído!" -ForegroundColor Green
