# Label Price Generator - Business Edition

Aplicatie desktop Windows x64 pentru gestionarea produselor si generarea etichetelor de pret.

## Functionalitati

- gestionare produselor din baza de date SQLite local
- import CSV
- export CSV
- previzualizare eticheta in timpul editarii
- export PDF cu lista produselor / etichete
- cod de bare auto-generat
- eticheta de tip retail standard
- design ready pentru optimizare ulterioara

## Tehnologii

- .NET 8 WPF
- SQLite local
- BarcodeLib
- QuestPDF

## Build local

```bash
dotnet restore src/LabelPriceGenerator/LabelPriceGenerator.csproj
dotnet build src/LabelPriceGenerator/LabelPriceGenerator.csproj -c Release -p:Platform=x64
```

## Publish pentru Windows x64

```bash
dotnet publish src/LabelPriceGenerator/LabelPriceGenerator.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:UseAppHost=true
```

## Urmatorul nivel

- print direct catre imprimanta termica
- sabloane multiple de etichete
- import Excel real
- arhivare stoc
- separare magazin / produse / etichete
- instalator .exe final

## Structura proiectului

- `src/LabelPriceGenerator` = aplicatia principala
- `src/LabelPriceGenerator/Models` = modelul produsului
- `src/LabelPriceGenerator/Services` = SQLite + PDF + previzualizare
- `installer` = loc pentru script-ul instalatorului final
