### Como correr el proyecto
+ clonar el repositorio
+ posicionarse en la carpeta del proyecto
+ abrir la consola y ejecutar el siguiente comando
    + docker-compose up
+ esperar a que se descarguen las imagenes y se configuren los entornos
+ verificar que los contenenedores dentro de api-restfull-net8 estén corriendo ejecutando el comando
    + docker ps
+ ir al navegador y probar con localhost:5024/swagger/index.html
+ se pueden realizar mas pruebas con postman utilizando la misma url y los metodos siguientes
    + GET /products
    + GET /products/{id}
    + POST /products
    + PUT /products/{id}
    + DELETE /products/{id}


### Para poder utilizar un ORM como Entity Framework en modo desarrollo habra que instalar los siguientes paquetes

+ dotnet add package Microsoft.EntityFrameworkCore
+ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
+ dotnet add package Microsoft.EntityFrameworkCore.Tools
+ dotnet add package Microsoft.EntityFrameworkCore.Design
