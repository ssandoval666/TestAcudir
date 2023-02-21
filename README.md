# TestAcudir

Test del BackEnd.

La webApi utiliza Swagger para la parte de front y prueba de los metodos. El mismo se implemento con la opcion
de versionado para en un futuro se pueda trabajar con versiones de los metodos. La unica version que esta 
disponible es la 1

Se implemento un token JWT, el mismo se tiene que ejecutar y anexar para para la ejecucion de los 
metodos de conrolador de People.

Los unicos parametros validos para generar un token son usr:test y pasw:test

Para el almacenamiento de la informacion se uso EF con SQLLite apuntando a una base en disco.
La misma se crea y se carga cuando le inicia la WebApi.
