<<<<<<< HEAD
# PLACKT-PROYECT
Proyecto de Gestión de Placas de Vehículos en Hoteles con Blazor

## Descripción

Este proyecto es una aplicación web desarrollada en C# con Blazor, diseñada para la gestión de vehículos que entran y salen de hoteles. El sistema permite a los usuarios llevar un registro de las placas de los vehículos, así como de los asuntos relacionados con los mismos, como robos o pérdidas. Además, ofrece un sistema de roles para usuarios y la capacidad de administrar múltiples empresas desde un solo servidor.

## Características Principales

### Gestion de Usuarios
![Gestión de Usuarios](/App_Images/Edit_User.jpg)

El sistema permite tener usuarios con tres roles diferentes: administrador, Manager y User Cada rol tiene diferentes permisos y capacidades dentro del sistema.

- **Administrador:** Los administradores pueden crear, editar, activar y desactivar cuentas de usuarios. Manejar la configuracion de los negocios y cambiar la configuracion de manejo del servidor, También pueden asignar roles y gestionar las contraseñas.
  
- **Manager:** Los Manager manejar los historiales y resolver los asuntos
  
- **Users:** Los Usuarios comunes solo pueden registrar los vehiculos que entran y salen, ademas de agregarle asuntos

## Registro de Entradas de Vehículos

![Registro de Entradas de Vehículos](/App_Images/add_arrival2.jpg)

- **Registro de Placas:** Los usuarios pueden registrar las placas de los vehículos que ingresan al hotel. Esto incluye información como la marca, modelo, color y detalles adicionales.

- **Historial de Entradas:** El sistema mantiene un historial completo de todas las entradas de vehículos, lo que permite un seguimiento detallado.

## Gestión de Asuntos

![Gestión de Asuntos](/App_Images/ISSUESPENDING.jpg)

- **Registro de Asuntos:** Los usuarios pueden agregar asuntos relacionados con los vehículos, como robos o pérdidas. Cada asunto incluye detalles importantes y se vincula con la placa del vehículo correspondiente.

- **Resolución de Asuntos:** Una vez resuelto un asunto, los usuarios pueden marcarlo como cerrado en el sistema.

## Gestión de Empresas

![Gestión de Empresas](/App_Images/Clients_page.jpg)

- **Múltiples Empresas:** El sistema puede gestionar varias empresas desde un solo servidor. Cada empresa tiene sus propios registros de vehículos y asuntos, y los usuarios pueden ser asignados a una empresa específica.

## Aplicación Móvil

También ofrecemos una versión móvil de nuestra aplicación para que pueda acceder y administrar su sistema de gestión de placas de vehículos en cualquier momento y en cualquier lugar. Nuestra aplicación móvil está disponible para dispositivos iOS y Android.

### Descarga la Aplicación

- **iOS**: [Descarga desde la App Store](enlace_de_la_app_ios)
- **Android**: [Descarga desde Google Play](enlace_de_la_app_android)

¡Lleva la gestión de placas de vehículos en hoteles en tu bolsillo con nuestra aplicación móvil!


## Requisitos del Sistema

- C# y .NET Core
- Blazor
- Base de Datos (puede ser SQL Server, MySQL, PostgreSQL, etc.)
- Dependencias adicionales (consulte el archivo de configuración para obtener detalles específicos)

## Configuración y Uso

1. Clone el repositorio a su servidor local.
2. Configure la base de datos y otros parámetros en el archivo de configuración.
3. Compile y ejecute la aplicación.

## Contribución

Si desea contribuir a este proyecto, siga estos pasos:

1. Forkee este repositorio en GitHub.
2. Clone el repositorio bifurcado a su máquina local.
3. Cree una nueva rama para su función o corrección de errores.
4. Haga sus cambios y envíe una solicitud de extracción.

## Licencia

Este proyecto está bajo la licencia [Licencia MIT](LICENSE).
