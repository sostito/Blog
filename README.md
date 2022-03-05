# Blog

Blog es una web api que permite gestionar el acceso de usuarios a funcionalidades como crear Post y agregar commentarios

## Requisitos obligatorios
- Sdk Net 6; https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## Requisitos opcinales
- ReportGenerator para generacion de reportes de manera gráfica; mediante consola se instala una unica vez: dotnet tool install -g dotnet-reportgenerator-globaltool

## Tecnologías usadas
- Net 6
- Entity Framework core
- Xunit
- Mapster
- Moq

## Observaciones 
- Pruebas unitarias > 85%
- Toda la solución se encuentra documentada mediante swagger
- El script de la base de datos (backup) se encuentra en el repositorio y se llama "Blog.bak"
- para actualizar el entorno gráfico de las pruebas unitarias basta con ejecutar los siguientes comandos en consola:
###### dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
###### reportgenerator -reports:"{reemplazarporurldecarpetalocal}\Test\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
- en caso de tener problemas al ejecturas las pruebas de manera gráifca, en el repositorio ya se tiene la ultima generada en la capeta de nombre "coveragereport" abriendo el archivo "index.html"

## Despliegue
- El desarrollo se encuentra desplegado en app service y tiene la siguiente URL: http://zemogablog.azurewebsites.net
- La base de datos es SQLSERVER y se encuentra desplegada en un host gratuito: https://somee.com/ 
