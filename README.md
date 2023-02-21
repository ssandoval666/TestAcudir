# TestAcudir

Test del BackEnd.


Se implemento un token JWT, el mismo se tiene que ejecutar y anexar para para la ejecucion de los 
metodos de conrolador de People.

Los unicos parametros validos para generar un token son usr:test y pasw:test

Para el almacenamiento de la informacion se uso EF con SQLLite apuntando a una base en disco.
La misma se crea y se carga cuando le inicia la WebApi.