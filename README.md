# Users API

## Descripción

Users API es un servicio web que permite gestionar usuarios, incluyendo funcionalidades de registro, inicio de sesión, actualización y eliminación de usuarios. Este proyecto utiliza ASP.NET Core, FastEndpoints, JWT para autenticación y cookies para la gestión de sesiones.

## Requisitos

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (o cualquier base de datos compatible)
- [Visual Studio](https://visualstudio.microsoft.com/) o cualquier editor de código compatible con .NET

## Instalación

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/tu_usuario/tu_repositorio.git
   cd tu_repositorio
   ```

2. **Configurar la base de datos**

   Asegúrate de tener una base de datos SQL Server configurada. Actualiza la cadena de conexión en `appsettings.json`:

   ```json
   "Database": {
     "ConnectionString": "Server=localhost;Database=DatabaseName;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }
   ```

3. **Instalar dependencias**

   Navega a la carpeta del proyecto y ejecuta el siguiente comando para restaurar las dependencias:

   ```bash
   dotnet restore
   ```

4. **Ejecutar la migración de la base de datos**

   Recomiendo utilizar Dapper y realizar la manipulación de la base de datos a través de consultas de SQL directas o a través de Microsoft SQL Server Management Studio

5. **Ejecutar la aplicación**

   Para iniciar la aplicación, utiliza el siguiente comando:

   ```bash
   dotnet run
   ```

   La API estará disponible en `https://localhost:5001/Swagger` (o el puerto que hayas configurado).

## Endpoints

### Autenticación

- **Login**
  - **Método**: `POST`
  - **Ruta**: `/login`
  - **Cuerpo**:
    ```json
    {
      "email": "usuario@example.com",
      "password": "tu_contraseña"
    }
    ```
  - **Respuesta**:
    - `200 OK`: Devuelve un token JWT y establece una cookie de autenticación.
    - `401 Unauthorized`: Credenciales inválidas.

- **Logout**
  - **Método**: `POST`
  - **Ruta**: `/logout`
  - **Respuesta**:
    - `204 No Content`: Cierra la sesión y elimina la cookie de autenticación.

### Gestión de Usuarios

- **Registrar Usuario**
  - **Método**: `POST`
  - **Ruta**: `/users`
  - **Cuerpo**:
    ```json
    {
      "username": "nuevo_usuario",
      "email": "usuario@example.com",
      "password": "tu_contraseña"
    }
    ```
  - **Respuesta**:
    - `201 Created`: Usuario registrado exitosamente.
    - `400 Bad Request`: Validación fallida.

- **Obtener Todos los Usuarios**
  - **Método**: `GET`
  - **Ruta**: `/users`
  - **Respuesta**:
    - `200 OK`: Devuelve una lista de usuarios.
    - `401 Unauthorized`: No autenticado.

- **Actualizar Usuario**
  - **Método**: `PUT`
  - **Ruta**: `/users/{id}`
  - **Cuerpo**:
    ```json
    {
      "username": "usuario_actualizado",
      "email": "usuario_actualizado@example.com",
      "password": "nueva_contraseña"
    }
    ```
  - **Respuesta**:
    - `200 OK`: Usuario actualizado exitosamente.
    - `404 Not Found`: Usuario no encontrado.

- **Eliminar Usuario**
  - **Método**: `DELETE`
  - **Ruta**: `/users/{id}`
  - **Respuesta**:
    - `204 No Content`: Usuario eliminado exitosamente.
    - `404 Not Found`: Usuario no encontrado.

## Configuración de Logging

El proyecto utiliza Serilog para el registro de eventos. Puedes configurar la ruta del archivo de log y la URL del servidor Seq, se debe crear un archivo `.env` en la raíz de Users.Api o directamente en `appsettings.json`.

El archivo `env` debería lucir así:
```env
LOG_FILE_PATH=ruta\log.txt

SEQ_SERVER_URL=http://localhost:5341
```

## Contacto

Para más información, puedes contactar a [migueldgdt@gmail.com].
