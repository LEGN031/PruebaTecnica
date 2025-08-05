<img width="1146" height="708" alt="image" src="https://github.com/user-attachments/assets/1086abd5-bddf-420d-af1a-e6ccd964219d" />🗳️ Sistema de Votaciones

Este es un sistema (RESTful API) de votaciones desarrollado en C# con arquitectura en capas, que permite gestionar votaciones, candidatos y votantes. Está construido sobre tecnologías como ASP.NET Core, Entity Framework y SQL Server.

📦 Estructura del proyecto

- lib_dominio: Contiene las entidades (modelos) del sistema.
- lib_aplicaciones: Lógica de negocio (servicios, interfaces e implementación).
- lib_repositorio:  Capa de conexión con la base de datos.
- db_votaciones.sql: Script para crear la base de datos.
- asp_servicios:  API encargada controladores, endpoints y configuracion de rutas.

🚀 Funcionalidades principales

- Registrar, listar, modificar y eliminar candidatos.
- Registrar, listar, modificar y eliminar votantes.
- Emitir, listar y eliminar votos.
- Obtener estadísticas de votación (porcentaje, total de votos).
- Control de usuarios que ya han votado.

🛠️ Tecnologías usadas

- .NET 6 / .NET 7
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Newtonsoft.json

El sistema está constituido como un proyecto en capas escalable a arquitectura MVC, se encuentra vinculado a la base datos por medio de un StringConexion definido en un archivo JSON local. Se encuentrra alojado en el puerto5218 de la maquina local.

Instrucciones:
- Para comenzar debe realizarse la autenticación que nos brinda un JWT temporal necesario para realizar las demás actividades, se debe definir un "Usuario" que es una clave definida en el programa y posteriormente encriptada usando AES 256.
<img width="1146" height="708" alt="JWT" src="https://github.com/user-attachments/assets/69b94c44-1645-4347-b8a6-dabdfe51eea0" />
El método se encuentra en la ruta "Token/Autenticar" y se accede por medio del protocolo POST por medio de un Body raw.

- Luego de esto se nos brinda el token necesario.
<img width="1152" height="199" alt="JWT 2" src="https://github.com/user-attachments/assets/a3d6170a-42b7-48c7-9ca6-d81e23d5b0fa" />

Para el resto de los métodos declararemos una variable JSON con head "Bearer" y el token que se nos brindó en el Body, para métodos como guardar y modificar declararemos también el objeto necesario según en lo que se quiera influír.

- Ejemplo de método guardar:
<img width="1201" height="414" alt="GuardarVotante" src="https://github.com/user-attachments/assets/7f68fc68-48b8-466a-bcd4-ed8562aafa36" />
Por medio del objeto brindado y el protocolo POST por medio de la ruta "API/Voter/Guardar" se realiza el guardado.

- Ejemplo de método buscar:
<img width="1202" height="730" alt="BuscarVotante" src="https://github.com/user-attachments/assets/09ac63d4-9e04-42fd-859e-d5c9a13e0f92" />
La ruta en este caso cambia un poco ya que se usa el patrón "API/Voter/{id}" y por medio de GET se realiza la peticion.

- Ejemplo de método borrar:
<img width="1207" height="731" alt="EliminarVotante" src="https://github.com/user-attachments/assets/33556fd1-3817-4887-99ed-d62c9a8eb743" />
De la misma manera que en el método buscar seguimos el patrón "API/Voter/{id}", el cambio en este caso sería la utilización de DELETE.

- Ejemplo de método listar:
<img width="1193" height="767" alt="ListarVotante" src="https://github.com/user-attachments/assets/a7f18edf-6897-49ff-9ea8-d2013ee2460d" />
En este caso la ruta sería "API/Voter/Listar", el proceso se hace por medio de GET.

Estos métodos se repiten para las demás clases, la modifcación necesaria sería cambiar el "Voter" de la ruta por "Vote" o "Candidate" dependiendo del caso. Aunque el "Vote" tiene algunas caracteristicas diferentes:

- Método buscar en Vote:
<img width="1199" height="728" alt="BuscarPorCode" src="https://github.com/user-attachments/assets/1a908791-3bc3-4d0e-aa41-a846afae92ea" />
Se envia un objeto con el campo codigo que se busca y con el protocolo GET regresa el objeto buscado.

- Método Statistics:
<img width="1204" height="732" alt="Statistics" src="https://github.com/user-attachments/assets/5ef13435-f96b-487d-bf08-055bb578c760" />
Este proceso es único de la clase vote y nos regresa un objeto con algunas estadisticas como el total de votos por candidato, porcentaje de votos por candidato, total de votantes que han votado.

---

## Realizado por:

- [Emanuel Medina Arboleda](https://tu-enlace.com)

---

## Licencia

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).




