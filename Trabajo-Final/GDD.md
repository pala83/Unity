# EL PUESTERO

## Documento de Diseño

6 de junio de 2024

Revision 1

**Ulises Palazzo**

----

# Indice

1. Cambios.
2. Introducción.
   1. Historia narrativa.
   2. Jugabilidad.
   3. 
3. Mecánicas de juego.
4. Interfaz.
5. Arte.

----

# Cambios

# Introducción
En el siguiente documento de diseño, se especificara a detalle la historia del protagonista "El Puestero", el cual es un puestero rural de un campo que esta en el interior de la provincia de Buenos Aires, el juego intentara recrear las distintas tareas agro-ganaderas que puede realizar un puestero rural luchando contra el clima, los mosquitos y las retenciones impositivas.  
EL juego tendrá progresividad, cada iteración representa un avance temporal de aproximadamente un mes, donde el puestero recibirá las ganancias o perdidas de su esfuerzo, las cuales puede aprovechar para comprar animales, sembrar, o power ups que facilitaran su labor.  

# Historia narrativa
Amadeo es el hijo mas grande de una familia de 5 integrantes fue nacido, criado y educado en el campo. Cuando finaliza sus estudios secundarios se dedica a trabajar de molinero con su tio.

Sus dos hermanos comenzaron carreras universitarias y gracias al esfuerzo de sus padres y de Amadeo pudieron mudarse a la capital de Buenos Aires a estudiar.

Pasados los años, Amadeo logra formar una pareja, uno de sus hermanos es agrimensor y el trabajo de molinero ahora lo ejerce de forma independiente.

Un dia su madre se pone muy enferma y durante la noche, el padre de Amadeo al sentir la elevada fiebre de su esposa decide hacer un viaje de urgencias a la ciudad para llevarla al hospital. Esa misma noche ambos fallecen en un accidente automovilístico.

Pasaron 8 años del accidente, Amadeo muy golpeado por la falta de sus padres ha llenado ese dolor con apuestas y alcohol, su vida se ha deteriorado al punto de que perdió a su pareja, esta muy endeudado y sus hermanos lo visitan muy poco. Esta situación hace que decida involucrarse en el cuatrerismo para pagar sus cuentas y mantener sus vicios, pero no le duraría mucho, ya que lo meten preso por un año.

El juego comienza con Amadeo a sus 36 años, arrepentido de su comportamiento decide volver al campo donde fue criado, ahi deberá trabajar cuidando los pocos animales que quedan y que forman parte de la sociedad que ha creado con sus dos hermanos, su hermano Agrimensor le proveerá lo necesario para que pueda cultivar las tierras y su otro hermano le conseguirá las herramientas necesarias para facilitarle el trabajo en el campo.

# Jugabilidad
Juego en tercera persona de estrategia 2D isométrico, donde controlaremos al puestero y con el haremos las tareas necesarias para hacer rendir el campo.

## Tareas
- Control del agua.
   - Reparar molino.
   - Reparar bebida.
   - Colocar bebida.
- Crear parcelas.
  - Colocar alambrado de 7 hilos.
  - Colocar alambrado eléctrico.
  - Colocar tranquera.
  - Colocar vela.
- Sembrar
  - Seleccionar parcelas a sembrar.
- Montar a caballo.
- Manejar moto.
- Manejar camioneta.
- Remate de asciendas.
- Repelente.
  - Comprar.
  - usar.

## Movimiento.
El puestero comenzara en el campo andando a pie, sera muy engorroso y peligroso, ya que cuando comienzan a aparecer los mosquitos correrá riesgo de muerte.
Deberá ingeniárselas para conseguir un caballo antes de que llegue la primavera para facilitar su trabajo, el cual podrá cambiar por una moto, o por una camioneta, al cual le dará inmunidad a los mosquitos.

En el terreno puede haber zonas inundadas, lagunas o zonas de mucho pasto, en las cuales andar cuesta mucho trabajo, y las lagunas no son accesible por la moto o la camioneta.

## Peligros.
Como mencionamos antes, los peligros a los que se enfrenta el puestero, son:
- El clima.
  - El cual puede ser favorable, o muy desfavorable hasta el punto que podría provocara una terrible invasión de mosquitos o inundar todo el campo.
- Los mosquitos.
  - Propagador de pestes, puede arruinar al ganado o al mismo puestero, hasta el punto de llegar a matarlo.
- Las retenciones impositivas.
  - Es difícil manejar las cuentas del campo y no fundirse en el intento, de cada rendimiento generado por el puestero, deberá pagar un porcentaje en impuestos, y otro porcentaje ira para la sociedad formada con sus hermanos, ya que también son dueños del campo.

## Terreno
El terreno sera una matriz en donde cada celda tendrá un valor numérico variante que hará referencia a distintos factores que puedan influenciar al terreno.
- Altitud del terreno $\in \lbrace -1,3 \rbrace$
- Cantidad de agua: $\in \lbrace -3,3 \rbrace$
  - Donde los valores negativos hacen referencia a un terreno seco.
- Cantidad de pasto $\in \lbrace 0,10 \rbrace$

![](/imagenes/mapa.png)
*Imagen de un mapa topografico, con sus valores truncados a parte entera inferior*

A su vez en cada celda puede haber un animal o un mosquito.  
También existen celdas con comportamiento diferente.


| Terreno    | Comportamiento |
|------------|----------------|
| **Lagunas**| - Una laguna es un terreno donde hay por lo menos 2 unidades más de agua que de altura del terreno. |
|            | - En las lagunas no hay pasto. |
|            | - En las lagunas no hay **pasturas**. |
|            | - Las lagunas son un **criadero de mosquitos**. |
|            | - Las motos y **camionetas** no pueden transitar en las lagunas. |
|**Pastizal**| - Los pastizales son zonas del terreno donde el pasto esta en nivel 10. |
|            | - Los pastizales son un **criadero de mosquitos** |
|            | - Las **camionetas** no pueden transitar en los pastizales |
| **Criadero de mosquitos** | - La probabilidad de que exista un mosquito es de 100% |
|                           | - La probabilidad de que te pique un mosquito es de 100% |
|                           | - Si existe un animal, le aumenta en +1 el riesgo ganadero |
| **Pastura** | - Las pasturas están fumigadas, no hay mosquitos |
|             | - Si existe 1 unidad de agua, aumenta el riesgo agropecuario en +1 |
|             | - Si existe un animal, aumenta el riesgo agropecuario en +2 |
|             | - Si existe una **camioneta**, aumenta el riesgo agropecuario en +3 |
| **Alambrado** | - Solo puede pararse sobre el alambrado el mosquito |
| **Tranquera** | - Igual que alambrado pero puede pasar el puestero, caballo, moto, camioneta |
| **Vela** | - Igual que la tranquera, pero puede pasar el animal |
| **Bebida** | - No hay pasto sobre la bebida |
|            | - Disminuye la altitud del terreno en 1 |
| **Camioneta** | - Disminuye el nivel del pasto $x$ en $x = \lceil x/2 \rceil$ |
|               | - No puede atropellar un animal. |
| **Moto**      | - Disminuye el nivel del pasto $x$ en $x = \lceil x/1.5 \rceil$ |
|               | - No puede atropellar un animal. |

## Mecánicas de juego
El juego cuenta con varias mecánicas que definen comportamientos y estrategias.

### Mecanica de clima
Como ya se comento, las iteraciones del juego representan un intervalo de tiempo de 1 mes.

Cada 3 meses en el juego ocurrirá un **cambio de estación** en las cuales se definen distintas variables que pueden influir en la jugabilidad:

| Mes       | Estación   | Probabilidad de Lluvia (%) | Crecimiento de pasto (%) | Probabilidad de mosquitos (%) |
|-----------|------------|----------------------------|--------------------------|-------------------------------|
| Enero     | Verano     | 30%                        | 150%                     | 100%                          |
| Febrero   | Verano     | 25%                        | 130%                     | 70%                           |
| Marzo     | Otoño      | 35%                        | 100%                     | 50%                           |
| Abril     | Otoño      | 40%                        | 80%                      | 20%                           |
| Mayo      | Otoño      | 45%                        | 60%                      | 10%                           |
| Junio     | Invierno   | 50%                        | 30%                      | 0%                            |
| Julio     | Invierno   | 55%                        | 20%                      | 0%                            |
| Agosto    | Invierno   | 50%                        | 40%                      | 10%                           |
| Septiembre| Primavera  | 40%                        | 100%                     | 20%                           |
| Octubre   | Primavera  | 35%                        | 150%                     | 50%                           |
| Noviembre | Primavera  | 30%                        | 180%                     | 70%                           |
| Diciembre | Verano     | 25%                        | 170%                     | 100%                          |

### Mecánica de ganado
Cada animal tendrá un comportamiento y una serie de parámetros que definirán su rendimiento en ganancia al final de cada iteración.  
El diagrama de estados de un vacuno sigue la siguiente forma:
Moverse -> Comer -> calcular rendimiento

#### Movimiento
Cada animal decide su movimiento guiándose por las celdas que son adyacentes a el y se moverá a la celda cuyo valor sea el MAXIMO, las celdas cuyo valor sea -1 son celdas inaccesibles para el animal, el valor de la celda sera el valor del nivel de pasto.

![](/imagenes/DecisionVaca.png)  
*Imagen que representa la toma de decisiones de una vaca*

##### Problemas
- Concurrencia: 2 vacas se mueven a la misma celda al mismo tiempo.
  - Se soluciona haciendo que 1 vaca se mueva a la vez, en ciclos de 1 segundo inicial, el cual se ira reduciendo dependiendo de la cantidad de vacas.
- Todas las celdas son -1: simple. la vaca no se moverá, esperara al siguiente ciclo.

#### Consumo
Cada vaca consume pasto y agua, para consumir agua debe estar dentro el rango de una bebida, y para consumir pasto debe estar en una celda, cuyo valor de pasto sea superior a 0.  
La vaca consume 4 unidades de pasto en la celda donde esta parada, y 2 unidades de pasto en todas sus celdas adyacentes.

#### Calculo de rendimiento
Para que una vaca genere altos rendimientos debe estar gorda