# Tp.Integrador.Softtek
# Desarrollo de API backend para empresa TechOil

El proyecto está desarrollado con Net Core 6 y Razor Pages

## **Especificación de la Arquitectura**

### **Capa Controller**
Será el punto de entrada a la API. En los controladores recibiremos las peticiones y las trasladaremos a la capa de servicios.

### **Capa DataAccess**
Es donde definiremos el DbContext, crearemos los seeds correspondientes y los repositorios para manejar nuestras entidades.

### **Capa Entities**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.

### **Capa DTOs**
En esta capa definiremos las clases correspondientes para acceder y exponer solo a la información de las entidades que necesitemos. 

### **Capa Core**
Es nuestra capa principal, en ella encontramos varios subniveles

*	Helper: Definiremos lógica que pueda ser de utilidad para todo el proyecto. Por ejemplo, un método para encriptar contraseñas
*	Interfaces: Se definirán las interfases que utilizaremos en los servicios.
*	Mapper: En esta carpeta irán las clases de mapeo para vincular entidad-dto o dto-entidad
*	Models: se definirán los modelos que necesitemos para el desarrollo. Dentro de esta carpeta encontramos DTO, para definirlos ahí dentro.
*	Services: Se incluirán todos los servicios solicitados por el proyecto.
