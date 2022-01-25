# bancoex
Created for knowledge evaluation

Este proyecto ha sido creado como parte de un examén de colocación y muestra de conocimientos;
aprovechando se impartio un mini-curso de desarrollo con .net 5 y angular con clean arch, en dos
sesiones de 1 hora.

Además de mostrar (en mi experiencia) como se implementa una aproximación de arquitectura limpia,
este proyecto servirá como base para la creación de proyectos con net 5 (por que mis escuchas no tienen
instalado VS 2022).

Estructura
- web : la parte mas cercana al usuario, se engloban los controllers, seguridad (en caso de tener),
  en este caso el uso de Angular, con la versión del template
- core : el centro de la aplicación; se crean las entities, servicios (reglas del negocio) e interfaces,
  y sí, no debería contener tanto en este proyecto pero si agregaba dos proyectos core y aplicación se
  complicaba la demostración, talvéz se implemente AutoMapper.
- persistencia : se implementan repositories, ef core y migrations; además se intentará utilizar in-memory
  para la base de datos, en caso de no lograrlo utilizaremos MS SQL.
  
Se espera crear una rama que contenga la migración a .net 6 con angular a la versión 13 (la última al
momento que se escribe) y una rama con la versión de vue 3, estos cambios espero los veamos en el
mes de febrero 2022.

Espero este proyecto pueda acelerar o aclarar dudas en sus desarrollos.

Saludos.
