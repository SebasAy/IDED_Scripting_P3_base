# IDED_Scripting_P3_base

Sebastian Ayala - 000424790
Juan Sebastian Giraldo - 000425629

Target picture: https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/WA_80_cm_archery_target.svg/600px-WA_80_cm_archery_target.svg.png (retrieved on 22/10/2023)
Wind direction arrow: https://www.pngwing.com/en/free-png-tuhcc/download (retrieved on 25/10/2023)

-Se usan Los patrones de diseño singleton, observer y command.

### Singleton: 
En el código, vemos el uso de Instance en las clases RefactoredPlayerController y RefactoredGameController para asegurarse de que solo haya una instancia de estas clases.

### Command: 
El patrón de diseño Comando se utiliza en el código en la implementación de la interfaz ICommand y la clase ProcessShotCommand. 

### Observer :
Se utiliza para implementar eventos y notificaciones en Unity. Los eventos OnGameOver y OnArrowShot en RefactoredGameController y las suscripciones y desuscripciones a estos eventos en RefactoredUIController 

## Razones por las cuales no usamos el patrón state:

**Simplicidad:**  El prototipo se centra en demostrar las mecánicas clave del juego de manera simple y efectiva. La implementación del patrón State añadiría complejidad innecesaria.

**Tiempo y Recursos Limitados:** La creación de múltiples estados y transiciones llevaría tiempo adicional de desarrollo. Queremos entregar el prototipo a tiempo.

**Naturaleza del Prototipo:** No buscamos una versión completa del juego, solo demostrar conceptos centrales de jugabilidad.

### Alternativa:
Hemos optado por una estructura de código más simple para enfocarnos en nuestros objetivos principales.

### Conclusión:
No utilizar el patrón State en el prototipo actual nos permite priorizar la simplicidad y cumplir con el plazo. 
