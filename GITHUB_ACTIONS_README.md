# GitHub Actions Workflows

Este repositório inclui dois workflows do GitHub Actions para automatizar o build e release da aplicação.

## 📋 Workflows Disponíveis

### 1. Build and Test (`build-and-test.yml`)
Este workflow é executado automaticamente em:
- Push para branches `main`, `master` ou `develop`
- Pull requests para essas branches
- Execução manual via interface do GitHub

**Funcionalidades:**
- ✅ Build da aplicação em modo Debug e Release
- ✅ Verificação de artefatos gerados
- ✅ Cache de dependências NuGet
- ✅ Upload de artefatos de build
- ✅ Validação da estrutura do projeto

### 2. Build and Release (`build-and-release.yml`)
Este workflow é executado quando:
- Uma tag com formato `v*` é criada (ex: `v1.0.0`, `v2.1.3`)
- Execução manual via interface do GitHub

**Funcionalidades:**
- 🚀 Build da aplicação em modo Release
- 📦 Publicação da aplicação com dependências
- 🎁 Criação de pacote ZIP para distribuição
- 📝 Geração automática de changelog
- 🏷️ Criação de release no GitHub
- 📎 Upload de arquivos da release

## 🚀 Como Fazer uma Release

### Método 1: Via Tag Git
```bash
# Crie e envie uma tag
git tag v1.0.0
git push origin v1.0.0
```

### Método 2: Via Interface do GitHub
1. Vá para a aba **Releases** no repositório
2. Clique em **Create a new release**
3. Digite uma tag no formato `v1.0.0`
4. Preencha o título e descrição
5. Clique em **Publish release**

### Método 3: Execução Manual
1. Vá para a aba **Actions** no repositório
2. Selecione **Build and Release**
3. Clique em **Run workflow**
4. Escolha a branch e clique em **Run workflow**

## 📁 Estrutura da Release

Cada release incluirá:

```
Poc.NfseIntegracao.App-v1.0.0.zip
├── Poc.NfseIntegracao.App.exe      # Aplicativo principal
├── Newtonsoft.Json.dll             # Dependência JSON
├── Poc.NfseIntegracao.App.dll      # Biblioteca da aplicação
├── *.json                          # Arquivos de configuração
└── XSDs/                           # Schemas de validação
    ├── DPS_v1.00.xsd
    ├── evento_v1.00.xsd
    ├── NFSe_v1.00.xsd
    └── ...
```

## 🔧 Requisitos do Sistema

### Para Desenvolvimento:
- ✅ .NET 9.0 SDK
- ✅ Windows 10/11
- ✅ Visual Studio 2022 ou VS Code

### Para Execução:
- ✅ Windows 10/11
- ✅ .NET 9.0 Runtime (instalado automaticamente se necessário)

## 📊 Status dos Workflows

Os badges abaixo mostram o status atual dos workflows:

![Build and Test](https://github.com/[SEU-USUARIO]/[SEU-REPOSITORIO]/workflows/Build%20and%20Test/badge.svg)
![Build and Release](https://github.com/[SEU-USUARIO]/[SEU-REPOSITORIO]/workflows/Build%20and%20Release/badge.svg)

## 🛠️ Personalização

### Modificar Versão do .NET
Edite a variável `DOTNET_VERSION` nos arquivos de workflow:
```yaml
env:
  DOTNET_VERSION: '9.0.x'  # Altere para a versão desejada
```

### Alterar Triggers
Modifique a seção `on:` para personalizar quando os workflows são executados:
```yaml
on:
  push:
    branches: [ main, develop ]  # Adicione/remova branches
  pull_request:
    branches: [ main ]
```

### Customizar o Changelog
Edite a seção "Generate changelog" no workflow de release para personalizar as informações incluídas.

## 📝 Notas Importantes

1. **Permissões**: Os workflows precisam de permissões para criar releases. Certifique-se de que `GITHUB_TOKEN` tenha as permissões necessárias.

2. **Tags**: Use sempre o formato `v*` para tags de release (ex: `v1.0.0`, `v2.1.3-beta`).

3. **Cache**: O workflow de build usa cache para acelerar as builds subsequentes.

4. **Artefatos**: Os artefatos de build ficam disponíveis por 7 dias após cada execução.

## 🤝 Contribuição

Para contribuir com melhorias nos workflows:
1. Faça fork do repositório
2. Crie uma branch para suas alterações
3. Teste as modificações
4. Abra um Pull Request

## 📞 Suporte

Se encontrar problemas com os workflows, verifique:
- ✅ Logs na aba **Actions** do GitHub
- ✅ Configurações de permissões do repositório
- ✅ Formato das tags de release
- ✅ Estrutura do projeto .NET
