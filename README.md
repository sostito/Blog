# Blog

Blog es una web api que permite gestionar el acceso de usuarios a funcionalidades como crear Post y agregar commentarios

## Tabla de contenido
1. [Requisitos obligatorios](#requisitos-obligatorios)
2. [Requisitos opcionales](#requisitos-opcionales)
3. [Tecnologías usadas](#tecnologías-usadas)
4. [Como funciona](#como-funciona)
5. [Observaciones](#observaciones)
6. [Despliegue](#despliegue)
7. [Credenciales de prueba](#credenciales)
8. [EndPoints disponibles](#endpoints-disponibles)
9. [EndPoints disponibles](#estructura-peticiones)
10. [Contacto](#contacto)

## Requisitos obligatorios
<a name="requisitos-obligatorios"></a>
- Sdk Net 6; https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## Requisitos opcionales
<a name="requisitos-obligatorios"></a>
- ReportGenerator para generacion de reportes de manera gráfica; mediante consola se instala una unica vez: dotnet tool install -g dotnet-reportgenerator-globaltool

## Tecnologías usadas
<a name="requisitos-obligatorios"></a>
- Net 6
- Entity Framework core
- Xunit
- Mapster
- Moq

## Como funciona
<a name="como-funciona"></a>
1. Para acceder a funciones protegidas segun enunciado se necesita un JWT de tipo bearer el cual debe ser enviado en la cabecera de la petición, y se puede obtener mediante el endpoint(POST) http://zemogablog.azurewebsites.net/api/User/Login
2. Los endpoint accesibles sin ningun tipo de usuario son los utilizados para obtener lista de comentarios ya aprobados, escribir comentarios, realizar login y crear nuevo usuario
3. Solo los usuarios con rol "writer" pueden crear nuevos comentarios
4. Solo los usuarios con rol "editor" pueden listar los post pendientes de aprobación, como tambien aprobarlos o eliminarlos

## Observaciones 
<a name="observaciones"></a>
- Pruebas unitarias > 85%
- Toda la solución se encuentra documentada mediante swagger
- El script de la base de datos (backup) se encuentra en el repositorio y se llama "Blog.bak"
- para actualizar el entorno gráfico de las pruebas unitarias basta con ejecutar los siguientes comandos en consola:
###### dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
###### reportgenerator -reports:"{reemplazarporurldecarpetalocal}\Test\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
- en caso de tener problemas al ejecturas las pruebas de manera gráfica, en el repositorio ya se tiene la ultima generada en la capeta de nombre "coveragereport" y se pueden visualizar abriendo el archivo "index.html"


## Despliegue
<a name="despliegue"></a>
- El desarrollo se encuentra desplegado en app service y tiene la siguiente URL base: http://zemogablog.azurewebsites.net
- La base de datos es SQL Server y se encuentra desplegada en un host gratuito: https://somee.com/ 

<a name="credenciales"></a>
## Credenciales de prueba
- writer: {
    "UserName": "writer",
    "Password": "1224"
}
- editor: {
    "UserName": "editor",
    "Password": "1224"
}

## EndPoints disponibles
<a name="endpoints-disponibles"></a>
### Get
1. http://zemogablog.azurewebsites.net/api/Post/GetPassedPost
2. http://zemogablog.azurewebsites.net/api/Post/GetNotPassedPost
3. http://zemogablog.azurewebsites.net/api/Post/ApprovePost/{postId}
4. http://zemogablog.azurewebsites.net/api/Post/DeletePost/{postId}

### Post
1. http://zemogablog.azurewebsites.net/api/User/Login
2. http://zemogablog.azurewebsites.net/api/User/CreateUser
3. http://zemogablog.azurewebsites.net/api/Post/WritePost
4. http://zemogablog.azurewebsites.net/api/Post/WriteComment

#### Estructura de peticiones de tipo POST
<a name="estructura-peticiones"></a>
1. Login: {
  "userName": "string",
  "password": "string"
}
2. CreateUser: {
  "userName": "string",
  "role": "string",
  "password": "string"
}
3. WritePost: {
  "content": "string"
}
4. WriteComment: {
  "text": "string",
  "idPost": 0
}

### Contacto
<a name="estructura-peticiones"></a>
Correo : freddymauran@gmail.com
