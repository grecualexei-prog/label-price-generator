# Label Price Generator

Aplicatie desktop Windows x64 pentru generarea si printarea etichetelor de pret.

## Caracteristici

- catalog produse local
- import din CSV sau Excel (gestionat la nivel de utilizator prin Excel/CSV)
- campuri: nume, pret, pret promotional, unitate de masura, cod de bare
- generare automata de coduri de bare
- previzualizare eticheta
- export PDF
- salvare local in format JSON
- model standard gata pentru extindere
- instalator .exe x64 prin publicare Windows

## Cerinte de sistem

- Windows 10/11 x64
- .NET 8 SDK pentru build
- Inno Setup pentru generarea instalatorului (.exe), optional

## Build

```bash
dotnet restore src/LabelPriceGenerator/LabelPriceGenerator.csproj
dotnet build src/LabelPriceGenerator/LabelPriceGenerator.csproj -c Release -p:Platform=x64
```

## Publish pentru Windows x64

```bash
dotnet publish src/LabelPriceGenerator/LabelPriceGenerator.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:UseAppHost=true
```

## Instalator .exe

Exista un template Inno Setup in folderul `installer/LabelPriceGenerator.iss`.

Inno Setup poate fi folosit pentru a genera un exe de instalare x64 din folderul de publish.

## Structura proiectului

- `src/LabelPriceGenerator` - aplicatia desktop principal
- `installer` - script Inno Setup pentru instalator

## Next steps

Dupa varianta standard, pot fi adaugate:

- design de eticheta personalizabil
- preturi pe mai multe lini
- import si export complet Excel
- printare direct catre imprimanta termica
- tipuri multiple de etichete
- login / contabilitate / stoc
